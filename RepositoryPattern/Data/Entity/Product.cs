using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern.Data.Entity
{
    public class Product
    {
        [Key]
        public int Product_PK { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }
       
        public string Image { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        public float? Discount { get; set; }

        public decimal? DiscountPrice { get { return Price.GetValueOrDefault() - (Price.GetValueOrDefault() * (decimal)Discount.GetValueOrDefault(0) / 100); } }

        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int Category_FK { get; set; }
        public Category Category { get; set; }
    }
}
