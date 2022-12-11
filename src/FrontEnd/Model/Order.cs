namespace BlazorServerClient.Model;

public class Order 
{
    public string Id {get;set;}

    public IEnumerable<Product> Products { get; set; }
}