using Serilog;
using Serilog.Core;
using Serilog.Events;

// Sinks();

// OutputTemplates();

// MinimumLevel();

// OverridingPerSink();

Enrichers();

static void Sinks()
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console() // Writes log events into console
        .WriteTo.File("./log-sinks-.txt", rollingInterval: RollingInterval.Day) // Writes log event into file text
        .CreateLogger();
    Log.Information("Hello world!");

    // Finally, once just before the application exits...
    Log.CloseAndFlush();

}

static void OutputTemplates()
{
    Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Writes log events into console
    .WriteTo.File("./log-output-templates-.txt",
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:w4}] {Message:lj}{NewLine}{Exception}",
        rollingInterval: RollingInterval.Day // Writes log event into file text
    )
    .CreateLogger();
    Log.Information("Hello world!");

    // Finally, once just before the application exits...
    Log.CloseAndFlush();
}

static void MinimumLevel()
{
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information() // Writes log events info and higher levels
        .WriteTo.Console()
        .CreateLogger();

    Log.Information("Inf -----> Hello world!");
    Log.Error("Err -----> Hello world!");
    Log.Debug("Deb ----> Hello world!");

    // Finally, once just before the application exits...
    Log.CloseAndFlush();
}

static void OverridingPerSink()
{
    Log.Logger = new LoggerConfiguration()
       .MinimumLevel.Debug()
       .WriteTo.File("log-overriding-per-sink.txt")
       .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
       .CreateLogger();

    Log.Information("Inf -----> Hello world!");
    Log.Error("Err -----> Hello world!");
    Log.Debug("Deb ----> Hello world!");

    // Finally, once just before the application exits...
    Log.CloseAndFlush();
}

static void Enrichers()
{
    Log.Logger = new LoggerConfiguration()
        .Enrich.With(new ThreadIdEnricher())
        .Enrich.WithProperty("Version", "1.0.0")
        .WriteTo.Console(
            outputTemplate: "{Timestamp:HH:mm} [{Level:u3}] ({ThreadId})-{Version} {Message}{NewLine}{Exception}"
        )
        .CreateLogger();

    Log.Information("Inf -----> Hello world!");
        
    // Finally, once just before the application exits...
    Log.CloseAndFlush();
}

class ThreadIdEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(
            propertyFactory.CreateProperty("ThreadId", Guid.NewGuid())
        );
    }
}