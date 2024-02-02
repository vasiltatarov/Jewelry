namespace Jewelry.Data.Repository.IRepository;

using Jewelry.Models.DbModels;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category entity);
}
