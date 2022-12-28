using System;
using System.Collections.Generic;
using System.Linq;
using Throttling.Record;

namespace Throttling.Repository;
public class ProductRepository : IProductRepository
{
    private readonly Dictionary<Guid, Product> _products = new();
    private Random _rnd = new Random();
    public ProductRepository()
    {
        InitializeProductStore();
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
        //Creating 5 random sample products
        for (var i = 0; i < 5; i++)
        {
            var id = Guid.NewGuid();
            _products.Add(id, new Product(id, $"Sample Product {i+1}", _rnd.Next(40, 50), _rnd.Next(1, 5)));
        }
    }
}

