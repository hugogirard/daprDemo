namespace BlazorServerClient.Services;

public class OrderService : IOrderService
{
    private readonly DaprClient _daprClient;

    public OrderService(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public async Task SendOrder(Order order)
    {
        await _daprClient.PublishEventAsync<Order>("pubsub", "order", order);
    }
}