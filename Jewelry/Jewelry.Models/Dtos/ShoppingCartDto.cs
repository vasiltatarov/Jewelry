namespace Jewelry.Models.Dtos;

public class ShoppingCartDto
{
    public int Id { get; set; }

    public int Count { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public string ProductDescription { get; set; }

    public double ProductPrice { get; set; }

    public string ProductImageUrl { get; set; }

    public string UserId { get; set; }
}
