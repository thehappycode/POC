using MiniIO.Applcation.Extensions;
using MiniIO.Applcation.Interfaces;
using MiniIO.Applcation.Services;
using minio.Options;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MinIOOptions>(
    builder.Configuration.GetSection(nameof(MinIOOptions))
);

builder.Services.AddMinIO(builder.Configuration);

builder.Services.AddScoped<IMinIOService, MinIOService>();

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

app.MapControllers();

app.Run();
