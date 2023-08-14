using NSE.Core.Messages.Integrations;
using NSE.MessageBus.Interfaces;
using NSE.Orders.API.Application.Queries.Interfaces;

namespace NSE.Orders.API.Services;

public class OrchestratorOrderIntegrationHandler : IHostedService, IDisposable
{
    private readonly ILogger<OrchestratorOrderIntegrationHandler> _logger;
    private readonly IServiceProvider _serviceProvider;
    private Timer _timer;

    public OrchestratorOrderIntegrationHandler(
        ILogger<OrchestratorOrderIntegrationHandler> logger,
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Serviço de pedidos iniciado.");
        _timer = new Timer(ProcessOrders, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Serviço de pedidos finalizado.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    private async void ProcessOrders(object state)
    {
        using var scope = _serviceProvider.CreateScope();
        var orderQueries = scope.ServiceProvider.GetRequiredService<IOrderQueries>();
        var order = await orderQueries.GetAuthorizedOrdersAsync();

        if (order == null) return;

        var bus = scope.ServiceProvider.GetRequiredService<IMessageBus>();
        var authorizedOrder = new AuthorizedOrderIntegrationEvent(
            order.CustomerId,
            order.Id,
            order.OrderItems.ToDictionary(o => o.ProductId, o => o.Quantity));

        await bus.PublishAsync(authorizedOrder);

        _logger.LogInformation($"Pedido ID: {order.Id} foi encaminhado para baixa no estoque.");
    }
}