using MetricExample.Api;
using OpenTelemetry;
using OpenTelemetry.Metrics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<CustomMetric>();

builder.Services.AddOpenTelemetry()
    .WithMetrics(x => 
        x
        .AddMeter("*")
        .AddConsoleExporter()
        .AddPrometheusExporter(opt =>
        {
           // opt.StartHttpListener = true;
          //  opt.HttpListenerPrefixes = new string[] { $"http://localhost:9184/" };
        }));


var app = builder.Build();

app.UseOpenTelemetryPrometheusScrapingEndpoint();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
