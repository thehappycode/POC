
using Common.Constants;
using Common.Etos;
using MassTransit;
using Newtonsoft.Json;
using Serilog;

namespace Dentination.Consumers;

public class OrderCreateConsumer : IConsumer<OrderCreateEto>
{
    public async Task Consume(ConsumeContext<OrderCreateEto> context)
    {
        await Task.Delay(1000);

        var message = JsonConvert.SerializeObject(context.Message);
        var correlationId = context.CorrelationId.ToString();
        Log.ForContext(CorrelationIdConstant.X_CORRELATION_ID_HEADER, correlationId)
        .Information(message);
    }
}