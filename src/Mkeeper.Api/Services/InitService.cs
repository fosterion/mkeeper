using Microsoft.EntityFrameworkCore;
using Mkeeper.Db;

namespace Mkeeper.Api.Services;

public class InitService : IHostedService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public InitService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        using var dbContext = scope.ServiceProvider.GetService<MkeeperContext>();

        await dbContext!.Database.MigrateAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
