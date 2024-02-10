namespace Jewelry.Data.Services;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Data.Services.IServices;
using Jewelry.Models.DbModels;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository shoppingCartRepository;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
    {
        this.shoppingCartRepository = shoppingCartRepository;
    }

    public void AddToCart(int productId, string userId, int count)
    {
        var cart = this.shoppingCartRepository.Get(x => x.ProductId == productId && x.UserId == userId);

        if (cart != null)
        {
            cart.Count += count;
            this.shoppingCartRepository.Update(cart);
        }
        else
        {
            cart = new ShoppingCart
            {
                ProductId = productId,
                UserId = userId,
                Count = count
            };
            this.shoppingCartRepository.Add(cart);
        }

        this.shoppingCartRepository.Save();
    }
}
