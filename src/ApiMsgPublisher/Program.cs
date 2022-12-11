using System.Text.Json.Serialization;
using Dapr;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Dapr will send serialized event object vs. being raw CloudEvent
app.UseCloudEvents();

// needed for Dapr pub/sub routing
app.MapSubscribeHandler();

// app.UseSwagger();
// app.UseSwaggerUI();


//app.UseHttpsRedirection();
        
app.MapPost("/orders", [Topic("pubsub", "order")] (Order order) => {
    Console.WriteLine("Subscriber received : " + order);
    return Results.Ok(order);
});


await app.RunAsync();

public record Order([property: JsonPropertyName("name")] string Name,
                    [property: JsonPropertyName("quantity")] int Quantity,
                    [property: JsonPropertyName("price")] int Price);