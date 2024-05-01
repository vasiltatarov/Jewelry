namespace Jewelry.Data.Services;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Data.Services.IServices;
using Jewelry.Models.DbModels;
using Jewelry.Models.Dtos;
using System.Collections.Generic;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository shoppingCartRepository;
    private readonly IImageService imageService;
    private readonly IApplicationUserRepository userRepository;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IImageService imageService, IApplicationUserRepository userRepository)
    {
        this.shoppingCartRepository = shoppingCartRepository;
        this.imageService = imageService;
        this.userRepository = userRepository;
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

    public List<ShoppingCartDto> GetAllForUser(string userId)
    {
        return this.shoppingCartRepository
            .GetAll(x => x.UserId == userId, "Product")
            .Select(x => new ShoppingCartDto
            {
                Id = x.Id,
                UserId = userId,
                Count = x.Count,
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                ProductDescription = x.Product.Description.Substring(0, 50),
                ProductPrice = x.Product.Price
            })
            .ToList();
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

    public double CalculateOrderTotal(List<ShoppingCartDto> shoppingCarts)
    {
        double total = 0;

        foreach (var cart in shoppingCarts)
        {
            total += cart.ProductPrice * cart.Count;
        }

        return total;
    }

    public void OrderDetailsForUser(OrderHeader orderHeader, string userId)
    {
        var user = this.userRepository.Get(x => x.Id == userId);

        orderHeader.User = user;
        orderHeader.Name = user.Name;
        orderHeader.Surname = user.Surname;
        orderHeader.Area = user.Area;
        orderHeader.City = user.City;
        orderHeader.Street = user.Street;
        orderHeader.StreetAddress = user.StreetAddress;
        orderHeader.PhoneNumber = user.PhoneNumber;
    }

    public void AddImagesToCarts(List<ShoppingCartDto> shoppingCarts)
    {
        var images = this.imageService.GetAll();

        foreach (var cart in shoppingCarts)
        {
            cart.ProductImageUrl = images.FirstOrDefault(x => x.ProductId == cart.ProductId)?.ImageUrl;
        }
    }

    public void ClearShoppingCarts(string userId)
    {
        var shoppingCarts = this.shoppingCartRepository.GetAll(x => x.UserId == userId);

        this.shoppingCartRepository.RemoveRange(shoppingCarts);
        this.shoppingCartRepository.Save();
    }
}
