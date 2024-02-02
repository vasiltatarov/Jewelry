namespace Jewelry.Data.Repository.IRepository;

using Jewelry.Models.DbModels;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product entity);
}
