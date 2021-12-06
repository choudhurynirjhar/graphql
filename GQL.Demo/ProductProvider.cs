namespace GQL.Demo;

public interface IProductProvider 
{ 
    Product[] GetProducts(); 
}

public class ProductProvider : IProductProvider
{
    private readonly IDataAccess dataAccess;

    public ProductProvider(IDataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }
    public Product[] GetProducts() => dataAccess.Get().ToArray();
}
