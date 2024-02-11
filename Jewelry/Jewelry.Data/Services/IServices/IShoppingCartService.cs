namespace Jewelry.Data.Services.IServices;

using Jewelry.Models.DbModels;
using Jewelry.Models.Dtos;

public interface IShoppingCartService
{
    void AddToCart(int productId, string userId, int count);

    List<ShoppingCart> GetAllForUser(string userId);
}
