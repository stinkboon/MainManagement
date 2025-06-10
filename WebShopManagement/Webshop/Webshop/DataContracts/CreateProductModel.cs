namespace Webshop.DataContracts;

public class CreateProductModel
{
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int Stock { get; set; }
        public int? DiscountPercentage { get; set; }
}