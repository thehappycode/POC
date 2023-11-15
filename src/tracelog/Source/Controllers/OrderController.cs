using Common.Constants;
using Common.Dtos;
using Common.Etos;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Source.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public OrderController(
        IPublishEndpoint publishEndpoint
    )
    {
        _publishEndpoint = publishEndpoint;
    }


    [HttpPost("CreateOrder")]
    public async Task<IActionResult> CreateOrder(OrderDto orderDto)
    {
        Log.Information("Start API");
        var correlationId = HttpContext.Request.Headers[CorrelationIdConstant.X_CORRELATION_ID_HEADER];
        Log.Information($"SourceCorrelationId: {correlationId}");
        await _publishEndpoint.Publish(new OrderCreateEto(
            default(int),
            orderDto.ProductName,
            orderDto.Price,
            orderDto.Quantity
        )
        //, sendContext => sendContext.ConversationId = !string.IsNullOrWhiteSpace(correlationId) ? Guid.Parse(correlationId) : Guid.NewGuid()
);

        Log.Information("End API");
        return Ok();
    }
}