# Serilog

## Getting Started

### Install

```dotnet
$ dotnet add package Serilog
$ dotnet add package Serilog.Sinks.Console
```

### Setup

Serilog namespace

```dotnet
using Serilog;
```

Tạo một root `Logger` sử dụng `LoggerConfiguration`

```dotnet
using var log = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
```

Sử dụng Serilog trong application thông qua `Log.Logger`

```dotnet
Log.Logger = log;
Log.Information("The global logger has been configured");
```

## Configuration Basics

### Creating a logger

```dotnet
Log.Logger = new LoggerConfiguration().CreateLogger();
Log.Information("No one listens to me!");

// Finally, once just before the application exits...
Log.CloseAndFlush();
```
### Sinks

Sinks là tạo ra các record log events được trình bày dưới dạng console, một file hoặc data store.

Sinks có 2 package được cài đặt thông qua Nuget

```dotnet
$ dotnet add package Serilog.Sinks.Console
$ dotnet add package Serilog.Sinks.File
```

- Console sink package: là pretty-prints log data.
```dotnet
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
    Log.Information("Ah, there you are!");
```

- File sink package: Ghi log events có date-stamped vào trong file text.
```dotnet
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
```


#### Output templates

Text-based sinks sử dụng *output templates* có dạng:

```dotnet
    .WriteTo.File("log.txt",
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
```
- **{Timestamp}**: Thời gian
- **{Level}**: ?
- **{Message:lj}**: Format dữ liệu được embedded vào trong message được output ra có dạng `JSON(j)` và mong muốn `string` literals(l)

### Minimun level

`MininumLevel` cung cấp cấu hình cho một log event levels và nó chính xác là events minium, khi đó những log event levels thấp hơn sẽ không được xử lý. Mặc định sẽ là `Information` level events.

### Overriding per sink

Đôi khi bạn muốn ghi detailed logs là trung bình, nhưng sẽ ít hơn detailed logs khác.

```dotnet
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("log.txt")
    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
    .CreateLogger();
```

Ví dụ trên sẽ ghi log `Debug` vào trong rolling file, và log `Information` và level cao hơn vào trong console.

### Enrichers

Enrichers đơn giản là những components add, remove or modifier các properties được attached đến log event. Nó có thể được sẻ dụng với mục đích attaching một thread id với mỗi event như ví dụ sau:

```dotnet
class ThreadIdEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                "ThreadId", Thread.CurrentThread.ManagedThreadId));
    }
}
```

Thêm cấu hình Enrichers vào configuration object.

```dotnet
Log.Logger = new LoggerConfiguration()
    .Enrich.With(new ThreadIdEnricher())
    .Enrich.WithProperty("Version", "1.0.0") // add properties
    .WriteTo.Console(
        outputTemplate: "{Timestamp:HH:mm} [{Level}] ({ThreadId}) {Version} {Message}{NewLine}{Exception}")
    .CreateLogger();
```


### Filters


### Sub-loggers
