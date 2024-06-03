using MassTransit;
using Microsoft.AspNetCore.Mvc;
using MTContracts;

namespace MTSender.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public MessageController(ISendEndpointProvider sendEndpointProvider)
    {
        _sendEndpointProvider = sendEndpointProvider;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MsgMT message)
    {
        var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:msgmt-queue"));
        await endpoint.Send(message);

        return Ok();
    }
}