namespace Webshop.DataContracts;

public class UpdateProductModel : CreateProductModel
{
    public required int Id { get; set; }
}