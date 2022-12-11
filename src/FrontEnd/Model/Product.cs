using System.Text.Json.Serialization;

namespace BlazorServerClient.Model;

public class Product 
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}