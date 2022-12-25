using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatalogWebApi.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductPriceType Type { get; set; }
        public string ExpirationDate { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
