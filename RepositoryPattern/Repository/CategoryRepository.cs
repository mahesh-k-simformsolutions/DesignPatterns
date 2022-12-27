using RepositoryPattern.Data;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
