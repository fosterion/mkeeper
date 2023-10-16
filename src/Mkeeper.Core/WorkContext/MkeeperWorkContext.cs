using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Mkeeper.Db;

namespace Mkeeper.Core.WorkContext;

public class MkeeperWorkContext : IWorkContext
{
    private readonly IDbContextTransaction _transaction;
    private readonly ILogger<MkeeperWorkContext> _logger;

    public MkeeperWorkContext(MkeeperContext context, ILogger<MkeeperWorkContext> logger)
    {
        _transaction = context.Database.BeginTransaction();
        _logger = logger;
    }

    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred during the commit operation");
            throw;
        }
    }

    public async Task RollbackAsync()
    {
        try
        {
            await _transaction.RollbackAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred during the rollback operation");
        }
    }
}
