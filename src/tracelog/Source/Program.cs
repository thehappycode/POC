using Common.Constants;
using Common.Extensions;
using Common.Filters;
using Common.Helpers;
using Common.Options;
using MassTransit;
using Newtonsoft.Json;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddCorrelationIdService();

builder.Services.AddHttpClientService();

builder.Services.AddHttpContextAccessor();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .MinimumLevel.Information()
        .WriteTo.Console()
        .WriteTo.File(
            "../Logs/log-.txt",
            rollingInterval: RollingInterval.Day,
            outputTemplate: SerilogConstant.OUTPUT_TEMPLATE,
            shared: true
        )
        .Enrich.WithCorrelationIdHeader(CorrelationIdConstant.X_CORRELATION_ID_HEADER)
        .ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddScoped(typeof(PublishFilter<>));

var rabbitMqOptions = builder.Configuration
    .GetSection(nameof(RabbitMqOptions))
    .Get<RabbitMqOptions>();
// Log.Information($"RabbitMqOptions: {JsonConvert.SerializeObject(rabbitMqOptions)}");
Console.WriteLine($"RabbitMqOptions: {JsonConvert.SerializeObject(rabbitMqOptions)}");
builder.Services.AddMassTransit(configure =>
{
    configure.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(
            rabbitMqOptions?.Host,
            rabbitMqOptions?.VirtualHost,
            c =>
            {
                c.Username(rabbitMqOptions?.Username);
                c.Password(rabbitMqOptions?.Password);
            });

        cfg.UsePublishFilter(typeof(PublishFilter<>), ctx);
    });
});

builder.Services.AddMassTransitHostedService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCorrelationId();

app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();
