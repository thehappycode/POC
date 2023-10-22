using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Writes log events into console
    .WriteTo.File("./log-.txt", rollingInterval: RollingInterval.Day) // Writes log event into file text
    .CreateLogger();
Log.Information("Hello world!");

// Finally, once just before the application exits...
Log.CloseAndFlush();