namespace Jewelry.Data.Services.IServices;

using Jewelry.Models.DbModels;

public interface ICategoryService
{
    void Add(Category category);

    void Update(Category category);

    void Delete(int id);

    List<Category> GetAll();

    Category GetById(int id);
}
