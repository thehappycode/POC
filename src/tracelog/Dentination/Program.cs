using Common.Constants;
using Common.Dtos;
using Common.Extensions;
using Common.Filters;
using Common.Helpers;
using Common.Options;
using Dentination.Consumers;
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

var rabbitMqOptions = builder.Configuration
    .GetSection(nameof(RabbitMqOptions))
    .Get<RabbitMqOptions>();

// Log.Information($"RabbitMqOptions: {rabbitMqOptions}");
Console.WriteLine($"RabbitMqOptions: {JsonConvert.SerializeObject(rabbitMqOptions)}");

// var busControl = Bus.Factory.CreateUsingRabbitMq(configure => 
// {
//     configure.Host(
//         rabbitMqOptions?.Host,
//         rabbitMqOptions?.VirtualHost,
//         cfg =>
//         {
//             cfg.Username(rabbitMqOptions?.Username);
//             cfg.Password(rabbitMqOptions?.Password);
//         });

//     // configure.UseConsumeFilter(typeof(ConsumeFilter<>), context,
//     //     x => x.Include(type => type.HasInterface<OrderCreatedConsumer>())
//     // );

//     configure.ReceiveEndpoint("order-created-event", e =>
//     {
//         // e.UseConsumeFilter(typeof(ConsumeFilter<>), context);
//         e.Consumer<OrderCreatedConsumer>();
//     });
// });

// await busControl
//     .StartAsync();

builder.Services.AddScoped(typeof(ConsumeFilter<>));
builder.Services.AddMassTransit(configure =>
{
    // configure.AddConsumer<OrderCreateConsumer>();
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

        cfg.ReceiveEndpoint("order-created-event", e =>
        {
            e.UseConsumeFilter(typeof(ConsumeFilter<>), ctx);
            e.Consumer<OrderCreateConsumer>();
        });
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