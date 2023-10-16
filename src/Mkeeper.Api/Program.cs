using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mkeeper.Api.Services;
using Mkeeper.Core.Repositories;
using Mkeeper.Core.WorkContext;
using Mkeeper.Db;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container
{
    builder.Services.AddHealthChecks()
        .AddNpgSql(builder.Configuration.GetConnectionString("Postgres")!);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddHostedService<InitService>();

    builder.Services.AddScoped<IWorkContext, MkeeperWorkContext>();

    builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(EntityFrameworkRepository<>));

    builder.Services.AddDbContext<MkeeperContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"))
            .UseSnakeCaseNamingConvention();
    });
}
#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseHealthChecks("/_health", new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

    app.UseAuthorization();

    app.MapControllers();
}
#endregion

app.Run();
