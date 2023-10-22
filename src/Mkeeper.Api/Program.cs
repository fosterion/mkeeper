using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Mkeeper.Api.Services;
using Mkeeper.Core.Repositories;
using Mkeeper.Db;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container
{
    var connection = builder.Configuration.GetConnectionString("Postgres")
        ?? throw new NotImplementedException();

    builder.Services.AddDbContext<MkeeperContext>(options =>
        options.UseNpgsql(connection).UseSnakeCaseNamingConvention());

    builder.Services.AddHealthChecks()
        .AddNpgSql(connection);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddHostedService<InitService>();
    builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
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
