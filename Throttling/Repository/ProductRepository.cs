using Throttling.Record;

namespace Throttling.Repository;
public class ProductRepository : IProductRepository
{
    private readonly Dictionary<Guid, Product> _products = new();
    private readonly Random _rnd = new();
    public ProductRepository()
    {
        for (int i = 0; i < 5; i++)
        {
            Guid id = Guid.NewGuid();
            _products.Add(id, new Product(id, $"Sample Product {i + 1}", _rnd.Next(40, 50), _rnd.Next(1, 5)));
        }
    }

    public List<Product> GetAll()
    {
        return _products.Values.ToList();
    }

    public Product GetById(Guid id)
    {
        return _products[id];
    }

    private void InitializeProductStore()
    {
    }
}

