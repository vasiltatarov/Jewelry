namespace Jewelry.Models.ViewModels;

using Jewelry.Models.DbModels;

public class ShoppingCartViewModel
{
    public List<ShoppingCart> ShoppingCartList { get; set; }

    public OrderHeader OrderHeader { get; set; }
}