namespace Jewelry.Data.Repository.IRepository;

using Jewelry.Models.DbModels;

public interface IImageRepository : IRepository<ProductImage>
{
    void Update(ProductImage entity);
}
