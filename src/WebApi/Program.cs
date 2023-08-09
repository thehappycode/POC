using Mongodb.BookStore.Datas;
using Mongodb.IServices;
using Mongodb.RestaurantStore.Datas;
using Mongodb.RestaurantStore.IServices;
using Mongodb.RestaurantStore.Services;
using Mongodb.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// BookStore
builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("Mongodb:BookStoreDatabase")
);
builder.Services.AddScoped<IBooksService, BooksService>();

// RestaurantStore
builder.Services.Configure<RestaurantDataSettings>(
    builder.Configuration.GetSection("Mongodb:RestaurantStoreDatabase")
);
builder.Services.AddScoped<IFindService, FindService>();
builder.Services.AddScoped<IInsertServcie, InsertServcie>();


builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null
    );
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
