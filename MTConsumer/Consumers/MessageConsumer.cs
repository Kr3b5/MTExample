using MassTransit;
using MTContracts;

namespace MTConsumer.Consumers;

public class MessageConsumer : IConsumer<MsgMT>
{
    private readonly ILogger<MessageConsumer> _logger;

    public MessageConsumer(ILogger<MessageConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MsgMT> context)
    {
        _logger.LogInformation("Received: {Text}", context.Message.Value);
        return Task.CompletedTask;
    }
}