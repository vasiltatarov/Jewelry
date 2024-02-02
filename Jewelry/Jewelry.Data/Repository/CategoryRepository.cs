namespace Jewelry.Data.Repository;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Models.DbModels;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext dbContext;

    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Update(Category entity)
    {
        this.dbContext.Categories.Update(entity);
    }
}
