namespace GQL.Demo;

public record Product(int Id, string Name, int Quantity);

public class ProductType : ObjectGraphType<Product>
{
    public ProductType()
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.Quantity);
    }
}

public class ProductQuery : ObjectGraphType
{
    public ProductQuery(IProductProvider productProvider)
    {
        Field<ListGraphType<ProductType>>(Name = "products", resolve: x => productProvider.GetProducts());
        Field<ProductType>(Name = "product", 
            arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            resolve: x => productProvider.GetProducts().FirstOrDefault(p => p.Id == x.GetArgument<int>("id")));
    }
}

public class ProductSchema : Schema
{
    public ProductSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<ProductQuery>();
        Mutation = serviceProvider.GetRequiredService<ProductMutation>();
    }
}