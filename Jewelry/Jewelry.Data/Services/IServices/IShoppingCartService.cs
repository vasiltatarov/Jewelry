namespace Jewelry.Data.Services.IServices;

public interface IShoppingCartService
{
    void AddToCart(int productId, string userId, int count);
}
