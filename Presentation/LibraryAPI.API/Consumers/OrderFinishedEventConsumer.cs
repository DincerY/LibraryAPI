using MassTransit;
using Shared.Events;

namespace LibraryAPI.API.Consumers;

public class OrderFinishedEventConsumer : IConsumer<OrderFinishedEvent>
{
    public Task Consume(ConsumeContext<OrderFinishedEvent> context)
    {
        Console.WriteLine(context.Message.OrderId);
        return Task.CompletedTask;
    }
}