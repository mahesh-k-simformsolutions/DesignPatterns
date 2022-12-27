using RepositoryPattern.Data;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryPattern.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
