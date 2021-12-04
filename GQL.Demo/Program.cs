global using GraphQL.Types;
global using GraphQL;

using GQL.Demo;
using GraphQL.Server;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProductProvider, ProductProvider>();
builder.Services.AddSingleton<ProductType>();
builder.Services.AddSingleton<ProductQuery>();
builder.Services.AddSingleton<ISchema, ProductSchema>();

builder.Services.AddGraphQL(opt => opt.EnableMetrics = false).AddSystemTextJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapGet("/api/products", ([FromServices] IProductProvider productProvider) =>
{
    return productProvider.GetProducts();
})
.WithName("GetProducts");

app.UseGraphQLAltair();
app.UseGraphQL<ISchema>();

app.Run();