using RepositoryPattern.Data.Entity;
using RepositoryPattern.Repository.Base;

namespace RepositoryPattern.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        public bool IsDiscountedProductExists(int categoryId);
    }
}
