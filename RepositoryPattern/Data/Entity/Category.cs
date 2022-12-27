using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Data.Entity
{
    public class Category
    {
        [Key]
        public int Category_PK { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private ICollection<Product> _products { get; set; }
        public virtual ICollection<Product> Products
        {
            get => _products ??= new HashSet<Product>();
            set => _products = value;
        }
    }
}
