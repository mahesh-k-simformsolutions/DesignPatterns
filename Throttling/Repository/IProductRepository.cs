using Throttling.Record;

namespace Throttling.Repository;

public interface IProductRepository
{
    Product GetById(Guid id);
    List<Product> GetAll();
}
