namespace Jewelry.Data.Repository.IRepository;

using Jewelry.Models.DbModels;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    void Update(ShoppingCart entity);
}