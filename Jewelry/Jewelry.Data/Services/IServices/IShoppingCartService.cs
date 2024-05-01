namespace Jewelry.Data.Services.IServices;

using Jewelry.Models.DbModels;
using Jewelry.Models.Dtos;

public interface IShoppingCartService
{
    void AddToCart(int productId, string userId, int count);

    List<ShoppingCartDto> GetAllForUser(string userId);

    void Plus(int cartId);

    void Minus(int cartId);

    void Remove(int cartId);

    double CalculateOrderTotal(List<ShoppingCartDto> shoppingCarts);

    void OrderDetailsForUser(OrderHeader orderHeader, string userId);

    void AddImagesToCarts(List<ShoppingCartDto> shoppingCarts);

    void ClearShoppingCarts(string userId);
}
