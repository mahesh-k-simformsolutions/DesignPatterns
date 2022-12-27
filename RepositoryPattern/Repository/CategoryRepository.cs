using RepositoryPattern.Data;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Repository.Base;
using System.Linq;

namespace RepositoryPattern.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public bool IsDiscountedProductExists(int categoryId)
        {
            return _context.Products.Any(p => p.Discount != null && p.Category_FK == categoryId);
        }
    }
}
