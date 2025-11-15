namespace E_Commerce.Shared.DataTransferObjects.Basket;

public class BasketItemDTO
{
    public int Id { get; set; }
    public string ProductName { get; init; }
    public string PictureUrl { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; set; }
    //ergfw
}