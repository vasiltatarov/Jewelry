namespace Jewelry.Data.Services.IServices;

using Jewelry.Models.DbModels;

public interface IProductService
{
    List<Product> GetAll();
}
