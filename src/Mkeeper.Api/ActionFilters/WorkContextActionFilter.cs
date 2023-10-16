using System.Reflection;
using System.Runtime.ExceptionServices;
using Microsoft.AspNetCore.Mvc.Filters;
using Mkeeper.Api.Attributes;
using Mkeeper.Core.WorkContext;

namespace Mkeeper.Api.ActionFilters;

public class WorkContextActionFilter : IAsyncActionFilter
{
    private readonly ILogger<WorkContextActionFilter> _logger;
    private static readonly HashSet<string> _workContextMethods = new()
    {
        HttpMethod.Post.Method,
        HttpMethod.Put.Method,
        HttpMethod.Patch.Method,
        HttpMethod.Delete.Method
    };

    public WorkContextActionFilter(ILogger<WorkContextActionFilter> logger)
    {
        _logger = logger;
    }

    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var useWorkContext = IsMethodAllowed(context) && IsNotIgnored(context);
        return useWorkContext ? ExecuteWithWorkContext(context, next) : next();
    }

    private static bool IsMethodAllowed(ActionExecutingContext context)
        => _workContextMethods.Contains(context.HttpContext.Request.Method);

    private static bool IsNotIgnored(ActionExecutingContext context)
        => context.Controller.GetType().GetCustomAttribute<IgnoreWorkContextAttribute>() == null;

    private async Task ExecuteWithWorkContext(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var workContext = context.HttpContext.RequestServices.GetService<IWorkContext>()
            ?? throw new InvalidOperationException($"Cannot resolve service {typeof(IWorkContext).FullName}");

        try
        {
            var actionResult = await next();

            if (actionResult.Exception is not null)
            {
                ExceptionDispatchInfo.Capture(actionResult.Exception).Throw();
            }

            await workContext.CommitAsync();
        }
        catch (Exception ex)
        {
            await workContext.RollbackAsync();

            _logger.LogError(ex, "An error occurred during request processing");
            throw;
        }
    }
}
