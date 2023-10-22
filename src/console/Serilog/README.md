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
