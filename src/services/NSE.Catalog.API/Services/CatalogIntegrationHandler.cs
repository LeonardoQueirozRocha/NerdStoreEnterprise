using NSE.Catalog.API.Data.Repositories.Interfaces;
using NSE.Catalog.API.Models;
using NSE.Core.DomainObjects;
using NSE.Core.Messages.Integrations;
using NSE.MessageBus.Interfaces;

namespace NSE.Catalog.API.Services;

public class CatalogIntegrationHandler : BackgroundService
{
    private readonly IMessageBus _bus;
    private readonly IServiceProvider _serviceProvider;

    public CatalogIntegrationHandler(
        IMessageBus bus,
        IServiceProvider serviceProvider)
    {
        _bus = bus;
        _serviceProvider = serviceProvider;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        SetSubscribers();
        return Task.CompletedTask;
    }

    private void SetSubscribers()
    {
        _bus.SubscribeAsync<AuthorizedOrderIntegrationEvent>("AuthorizedOrder", async request =>
        {
            await FreeStockAsync(request);
        });
    }

    private async Task FreeStockAsync(AuthorizedOrderIntegrationEvent message)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var productsInStock = new List<Product>();
            var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();

            var productIds = string.Join(",", message.Items.Select(x => x.Key));
            var products = await productRepository.GetProductsByIdAsync(productIds);

            if (products.Count != message.Items.Count)
            {
                CancelOrderOutOfStock(message);
                return;
            }

            foreach (var product in products)
            {
                var productQuantity = message.Items.FirstOrDefault(p => p.Key == product.Id).Value;

                if (product.IsAvailable(productQuantity))
                {
                    product.RemoveOfStock(productQuantity);
                    productsInStock.Add(product);
                }
            }

            if (productsInStock.Count != message.Items.Count)
            {
                CancelOrderOutOfStock(message);
                return;
            }

            productsInStock.ForEach(product => productRepository.Update(product));

            if (!await productRepository.UnitOfWork.Commit())
            {
                throw new DomainException($"Problemas ao atualizar o estoque do pedido {message.OrderId}");
            }

            var loweredOrder = new OrderWrittenOffFromStockIntegrationEvent(message.CustomerId, message.OrderId);
            await _bus.PublishAsync(loweredOrder);
        }
    }

    private void CancelOrderOutOfStock(AuthorizedOrderIntegrationEvent message)
    {
        var canceledOrder = new CanceledOrderIntegrationEvent(message.CustomerId, message.OrderId);
        _bus.PublishAsync(canceledOrder).Wait();
    }
}
