namespace Jewelry.Data.Services.IServices;

using Jewelry.Models.DbModels;

public interface ICategoryService
{
    List<Category> GetAll();
}
