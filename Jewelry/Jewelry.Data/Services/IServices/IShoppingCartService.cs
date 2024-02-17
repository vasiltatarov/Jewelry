namespace Jewelry.Data.Services.IServices;

using Jewelry.Models.DbModels;

public interface IShoppingCartService
{
    void AddToCart(int productId, string userId, int count);

    List<ShoppingCart> GetAllForUser(string userId);

    void Plus(int cartId);

    void Minus(int cartId);

    void Remove(int cartId);
}
