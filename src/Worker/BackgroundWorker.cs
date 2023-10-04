namespace Worker;

public class BackgroundWorker : BackgroundService
{
    private readonly ILogger<BackgroundWorker> _logger;

    public BackgroundWorker(ILogger<BackgroundWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
