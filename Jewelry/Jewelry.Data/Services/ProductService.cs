namespace Jewelry.Data.Services;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Data.Services.IServices;
using Jewelry.Models.DbModels;
using Jewelry.Models.Enumerations;
using System.Collections.Generic;

public class ProductService : IProductService
{
    private readonly IProductRepository productRepository;

    public ProductService(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public void Add(Product product)
    {
        this.productRepository.Add(product);
        this.productRepository.Save();
    }

    public void Update(Product product)
    {
        this.productRepository.Update(product);
        this.productRepository.Save();
    }

    public void Delete(Product product)
    {
        this.productRepository.Remove(product);
        this.productRepository.Save();
    }

    public List<Product> GetAll(string includeProperties)
    {
        return this.productRepository.GetAll(includeProperties: includeProperties).ToList();
    }

    public Product GetById(int id, string includeProperties = null)
    {
        return this.productRepository.Get(x => x.Id == id, includeProperties);
    }

    public Availability GetProductAvailability(Product product)
    {
        if (product.OutOfStock || product.Quantity < 1)
        {
            return Availability.OutOfStock;
        }
        else if (product.Quantity <= 10)
        {
            return Availability.LowAvailability;
        }
        else
        {
            return Availability.HighAvailability;
        }
    }
}
