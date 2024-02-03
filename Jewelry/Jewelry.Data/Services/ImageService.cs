namespace Jewelry.Data.Services;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Data.Services.IServices;
using Jewelry.Models.DbModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

public class ImageService : IImageService
{
    private readonly IImageRepository imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        this.imageRepository = imageRepository;
    }

    public ProductImage GetById(int id)
    {
        return this.imageRepository.Get(x => x.Id == id);
    }

    public bool ProcessFiles(IList<IFormFile> files, string rootPath, int productId)
    {
        try
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var productPath = @"images\products\product-" + productId;
                    var finalPath = Path.Combine(rootPath, productPath);

                    if (!Directory.Exists(finalPath))
                    {
                        Directory.CreateDirectory(finalPath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    var productImage = new ProductImage
                    {
                        ImageUrl = @"\" + productPath + @"\" + fileName,
                        ProductId = productId
                    };

                    this.imageRepository.Add(productImage);
                }

                this.imageRepository.Save();
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public int DeleteImage(string rootPath, int imageId)
    {
        try
        {
            var imageToBeDeleted = this.GetById(imageId);
            int productId = imageToBeDeleted.ProductId;

            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldImagePath = Path.Combine(rootPath, imageToBeDeleted.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                this.imageRepository.Remove(imageToBeDeleted);
                this.imageRepository.Save();
            }

            return productId;
        }
        catch (Exception)
        {
            return -1;
        }
    }

    public bool DeleteProductImages(string rootPath, int productId)
    {
        try
        {
            string productPath = @"images\products\product-" + productId;
            string finalPath = Path.Combine(rootPath, productPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);

                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
