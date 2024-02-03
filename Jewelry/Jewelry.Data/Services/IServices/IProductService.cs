namespace Jewelry.Data.Services.IServices;

using Jewelry.Models.DbModels;

public interface IProductService
{
    List<Product> GetAll(string includeProperties);

    Product GetById(int id);

    void Add(Product product);

    void Update(Product product);

    void Delete(Product product);
}
