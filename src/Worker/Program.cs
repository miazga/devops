using Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<BackgroundWorker>();
    })
    .Build();

host.Run();
