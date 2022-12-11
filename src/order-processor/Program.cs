using System.Text.Json.Serialization;
using Dapr;
using Dapr.Client;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDaprClient();
var app = builder.Build();

// Dapr will send serialized event object vs. being raw CloudEvent
app.UseCloudEvents();

// needed for Dapr pub/sub routing
app.MapSubscribeHandler();

if (app.Environment.IsDevelopment()) {app.UseDeveloperExceptionPage();}

// Dapr subscription in [Topic] routes orders topic to this route
app.MapPost("/orders", [Topic("pubsub", "order")] async (DaprClient daprClient, Order order) => {
    Console.WriteLine("Subscriber received : " + order);
    await daprClient.SaveStateAsync<Order>("statestore",order.Id, order);    
    return Results.Ok(order);
});

await app.RunAsync();


public record Order([property: JsonPropertyName("id")] string Id,
                    [property: JsonPropertyName("name")] string Name,
                    [property: JsonPropertyName("quantity")] int Quantity,
                    [property: JsonPropertyName("price")] int Price);