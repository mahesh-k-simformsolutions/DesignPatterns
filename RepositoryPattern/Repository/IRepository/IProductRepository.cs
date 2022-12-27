using RepositoryPattern.Data.Entity;
using RepositoryPattern.Repository.Base;

namespace RepositoryPattern.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
