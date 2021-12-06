namespace GQL.Demo;

public interface IProductCreator
{
    Product Create(Product product);
}

public class ProductCreator : IProductCreator
{
    private readonly IDataAccess dataAccess;

    public ProductCreator(IDataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }

    public Product Create(Product product)
    {
        dataAccess.Create(product);
        return product;
    }
}