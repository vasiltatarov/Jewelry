namespace Jewelry.Models.ViewModels;

using Jewelry.Models.DbModels;
using Jewelry.Models.Dtos;

public class ShoppingCartViewModel
{
    public ShoppingCartViewModel()
    {
        this.OrderHeader = new();
    }

    public List<ShoppingCartDto> ShoppingCartList { get; set; }

    public OrderHeader OrderHeader { get; set; }
}