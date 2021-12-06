namespace GQL.Demo;

public class ProductInput : InputObjectGraphType
{
    public ProductInput()
    {
        Field<IntGraphType>("id");
        Field<StringGraphType>("name");
        Field<IntGraphType>("quantity");
    }
}

public class ProductMutation : ObjectGraphType
{
    public ProductMutation(IProductCreator productCreator)
    {
        Field<ProductType>("createproduct",
            arguments: new QueryArguments { new QueryArgument<ProductInput> { Name = "product" } },
            resolve: x => productCreator.Create(x.GetArgument<Product>("product")));
    }
}