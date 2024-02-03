namespace Jewelry.Data.Repository;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Models.DbModels;

public class ImageRepository : Repository<ProductImage>, IImageRepository
{
    private readonly ApplicationDbContext dbContext;

    public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Update(ProductImage entity)
    {
        this.dbContext.ProductImages.Update(entity);
    }
}
