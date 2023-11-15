using GreenPipes;
using MassTransit;
namespace Common.Filters;

public class ConsumeFilter<TMessage> : IFilter<ConsumeContext<TMessage>>
    where TMessage : class
{
    public ConsumeFilter(
    )
    {
        Console.WriteLine("ConsumeFilter Contructor");
    }

    public async Task Send(ConsumeContext<TMessage> context, IPipe<ConsumeContext<TMessage>> next)
    {
        Console.WriteLine("ConsumeFilter Send");
        await next.Send(context);
    }

    public void Probe(ProbeContext context)
    {
        Console.WriteLine("ConsumeFilter Probe");
    }
}
