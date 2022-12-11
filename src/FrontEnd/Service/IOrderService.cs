namespace BlazorServerClient.Services;

public interface IOrderService
{
    Task SendOrder(Order order);
}
