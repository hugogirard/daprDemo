using System.Text.Json;
using BlazorServerClient.Model;

namespace BlazorServerClient.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {        
        var response = await _httpClient.GetAsync("api/products");
        if (response.IsSuccessStatusCode)
        {
            string serializedObject = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Product>>(serializedObject);
        }
        return new List<Product>();
        //return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/products") ?? new List<Product>();
    }
}