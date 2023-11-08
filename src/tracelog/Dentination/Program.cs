using Common.Constants;
using Common.Extensions;
using Common.Helpers;
using Serilog;
using Serilog.Core;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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