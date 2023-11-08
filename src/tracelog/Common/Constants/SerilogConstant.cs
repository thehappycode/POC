namespace Common.Constants;

public static class SerilogConstant
{
    // public const string OUTPUT_TEMPLATE =  @"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{X-Correlation-Id}] {Message:lj}{NewLine}{Exception}";
    public const string OUTPUT_TEMPLATE =  @"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{CorrelationId}] {Message:lj}{NewLine}{Exception}";
}