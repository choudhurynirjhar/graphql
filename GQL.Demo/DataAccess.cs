namespace GQL.Demo;
public interface IDataAccess
{
    void Create(Product product);
    IList<Product> Get();
}

public class DataAccess : IDataAccess
{
    private readonly List<Product> products = new List<Product>
        {
            new Product(1, "Laptop", 20),
            new Product(2, "Mouse", 30),
            new Product(3, "Keyboard", 10),
            new Product(4, "Monitor", 40)
        };

    public IList<Product> Get() => products;

    public void Create(Product product) { products.Add(product); }
}