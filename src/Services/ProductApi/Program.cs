var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(o => 
{
    o.RoutePrefix = string.Empty;
    o.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API");
});

app.UseHttpsRedirection();

app.MapGet("/api/products", () =>
{

    var products = new List<Product>
    {
        new Product("Tomato Soup"),
        new Product("Ceasar Salad"),
        new Product("Carrot Cake"),
        new Product("Pumpkin Pie"),
        new Product("Pecan Pie"),
        new Product("Apple Pie")
    };

    return products;
})
.WithName("GetProducts")
.WithOpenApi();

app.Run();

record Product(string Name);
