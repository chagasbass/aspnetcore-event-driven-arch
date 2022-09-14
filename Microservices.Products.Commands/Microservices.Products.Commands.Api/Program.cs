using Microservices.Products.Commands.Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Extensions.Extensions.Customs;
using MinimalApi.Extensions.Extensions.Documentations;
using MinimalApi.Extensions.Extensions.Logs;
using MinimalApi.Extensions.Extensions.Observability.Healthchecks;
using MinimalApi.Extensions.Extensions.Options;
using MinimalApi.Extensions.Extensions.Performance;
using MinimalApi.Extensions.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

Log.Logger = LogIntegrationsExtensions.ConfigureStructuralLogWithSerilog(configuration);
builder.Logging.AddSerilog(Log.Logger);

try
{
    Log.Information("Iniciando a aplicação");
    #region configuracoes das extensoes

    builder.Services.AddEndpointsApiExplorer()
                .AddBaseConfigurationOptionsPattern(configuration)
                .AddMemoryCache()
                .AddSwaggerDocumentation(configuration)
                .AddLogServiceDependencies()
                .AddNotificationControl()
                .AddAppHealthChecks()
                .AddMinimalApiPerformanceBoost()
                .AddDependencyInjection()
                .AddApiCustomResults()
                .AddFilterToSystemLogs()
                .AddGlobalExceptionHandlerMiddleware()
                .AddApiVersioning(x => x.DefaultApiVersion = ApiVersion.Default);

    #endregion

    var app = builder.Build();

    #region configuracoes dos middlewares

    app.UseResponseCompression()
       .UseSwagger()
       .UseSwaggerUI()
       .UseHealthChecks(configuration)
       .UseMiddleware<GlobalExceptionHandlerMiddleware>()
       .UseMiddleware<SerilogRequestLoggerMiddleware>()
       .UseHttpsRedirection();


    #endregion

    MapApiActions(app);

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminado inexperadamente.");
}
finally
{
    Log.CloseAndFlush();
}


void MapApiActions(WebApplication app)
{
    var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

    app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateTime.Now.AddDays(index),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");
}
internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

}