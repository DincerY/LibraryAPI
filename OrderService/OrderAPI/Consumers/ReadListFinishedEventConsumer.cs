using MassTransit;
using OrderAPI.Models.Entities;
using OrderAPI.Services;
using Shared.Events;

namespace OrderAPI.Consumers;

public class ReadListFinishedEventConsumer : IConsumer<ReadListFinishedEvent>
{
    private readonly IPublishEndpoint _endpoint;
    private readonly OrderService _orderService;
    private readonly ProductService _productService;

    public ReadListFinishedEventConsumer(IPublishEndpoint endpoint, OrderService orderService, ProductService productService)
    {
        _endpoint = endpoint;
        _orderService = orderService;
        _productService = productService;
    }

    public async Task Consume(ConsumeContext<ReadListFinishedEvent> context)
    {
        ReadListFinishedEvent readListFinishedEvent = context.Message;
        Order order = new()
        {
            UserId = readListFinishedEvent.UserId,
        };
        Order addedOrder = await _orderService.AddOrder(order);
        List<Product> products = await _productService.AddRangeProduct(context.Message.ProductId, addedOrder.Id);

    }
}