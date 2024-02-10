namespace Jewelry.Data.Services.IServices;

using Jewelry.Models.DbModels;
using Jewelry.Models.Enumerations;

public interface IProductService
{
    List<Product> GetAll(string includeProperties);

    Product GetById(int id, string includeProperties = null);

    void Add(Product product);

    void Update(Product product);

    void Delete(Product product);

    Availability GetProductAvailability(Product product);

    bool HasQuantity(int productId, int count);
}
