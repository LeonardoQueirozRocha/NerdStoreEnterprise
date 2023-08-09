namespace NSE.Orders.API.Services;

public class OrchestratorOrderIntegrationHandler : IHostedService, IDisposable
{
    private readonly ILogger<OrchestratorOrderIntegrationHandler> _logger;
    private Timer _timer;

    public OrchestratorOrderIntegrationHandler(ILogger<OrchestratorOrderIntegrationHandler> logger)
    {
        _logger = logger;
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

    private void ProcessOrders(object state)
    {
        _logger.LogInformation("Processando pedidos");
    }
}