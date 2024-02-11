namespace Jewelry.Data.Services.IServices;

using Jewelry.Models.DbModels;
using Microsoft.AspNetCore.Http;

public interface IImageService
{
    ProductImage GetById(int id);

    IEnumerable<ProductImage> GetAll();

    bool ProcessFiles(IList<IFormFile> files, string rootPath, int productId);

    int DeleteImage(string rootPath, int imageId);

    bool DeleteProductImages(string rootPath, int productId);
}
