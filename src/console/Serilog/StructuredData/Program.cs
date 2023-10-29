using Serilog;
using StructuredData;

SourceContexts();

Correlation();

static void SourceContexts()
{
    Log.Logger = new LoggerConfiguration()
            .WriteTo.Console() // Writes log events into console
            .WriteTo.File("./log-source-contexts-.txt", rollingInterval: RollingInterval.Day) // Writes log event into file text
            .CreateLogger();
    var myLog = Log.ForContext<MyClass>();
    myLog.Information("Hello world!");

    // Finally, once just before the application exits...
    Log.CloseAndFlush();

}


static void Correlation()
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console() // Writes log events into console
        .WriteTo.File("./log-source-contexts-.txt", rollingInterval: RollingInterval.Day) // Writes log event into file text
        .CreateLogger();

    Log.Information("Hello world!");

    var log = Log.ForContext("JobId", Guid.NewGuid());
    log.Information("Running a new job");
    // Finally, once just before the application exits...
    Log.CloseAndFlush();
}