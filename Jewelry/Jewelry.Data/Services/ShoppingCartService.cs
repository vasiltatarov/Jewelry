namespace Jewelry.Data.Services;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Data.Services.IServices;
using Jewelry.Models.DbModels;
using Jewelry.Models.Dtos;
using System.Collections.Generic;

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

    public List<ShoppingCart> GetAllForUser(string userId)
    {
        return this.shoppingCartRepository.GetAll(x => x.UserId == userId, "Product").ToList();

        //return shippongCarts.Select(x => new ShoppingCartDto
        //{
        //    Id = x.Id,
        //    UserId = userId,
        //    Count = x.Count,
        //    ProductId = x.ProductId,
        //    Product = x.Product
        //})
        //.ToList();
    }

    public void Plus(int cartId)
    {
        var cartItem = this.shoppingCartRepository.Get(x => x.Id == cartId);
        
        if (cartItem != null && cartItem.Count < 100)
        {
            cartItem.Count += 1;
            this.shoppingCartRepository.Update(cartItem);
            this.shoppingCartRepository.Save();
        }
    }

    public void Minus(int cartId)
    {
        var cartItem = this.shoppingCartRepository.Get(x => x.Id == cartId);

        if (cartItem != null && cartItem.Count > 1)
        {
            cartItem.Count -= 1;
            this.shoppingCartRepository.Update(cartItem);
            this.shoppingCartRepository.Save();
        }
    }

    public void Remove(int cartId)
    {
        var cartItem = this.shoppingCartRepository.Get(x => x.Id == cartId);

        if (cartItem != null)
        {
            this.shoppingCartRepository.Remove(cartItem);
            this.shoppingCartRepository.Save();
        }
    }
}
