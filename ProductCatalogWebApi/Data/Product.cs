namespace ProductCatalogWebApi.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductPriceType Type { get; set; }
        public string ExpirationDate { get; set; }
        public int CategoryId { get; set; }
    }
}
