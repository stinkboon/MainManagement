using Webshop.DataContracts;

namespace Webshop.MockData;

public static class MockProductList
{
    public static ProductListViewModel ProductList = new ProductListViewModel()
    {
        Products = [
            new ProductViewModel()
            {
                Id = 1,
                Name = "Pen",
                Description = "om te schrijven",
                Price = 25,
                Stock = 110,
                DiscountPercentage = 20
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Horloge",
                Description = "Tijd vertellen",
                Price = 150,
                Stock = 200,
                DiscountPercentage = 30
            }
        ]
    };
}