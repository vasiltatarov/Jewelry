namespace Jewelry.Models.Dtos;

using Jewelry.Models.DbModels;

public class ShoppingCartDto
{
    public int Id { get; set; }

    public int Count { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; }

    public string UserId { get; set; }

    public string ImageUrl { get; set; }
}
