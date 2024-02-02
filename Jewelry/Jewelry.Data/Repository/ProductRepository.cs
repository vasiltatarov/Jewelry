namespace Jewelry.Data.Repository;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Models.DbModels;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ApplicationDbContext dbContext;

    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Update(Product entity)
    {
        this.dbContext.Products.Update(entity);
    }
}
