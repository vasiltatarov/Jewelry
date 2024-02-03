namespace Jewelry.Data.Services.IServices;

using Jewelry.Models.DbModels;

public interface ICategoryService
{
    void Add(Category category);

    List<Category> GetAll();
}
