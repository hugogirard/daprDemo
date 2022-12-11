using BlazorServerClient.Model;

namespace BlazorServerClient.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
}
