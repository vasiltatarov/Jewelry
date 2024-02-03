namespace Jewelry.Data.Services;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Data.Services.IServices;
using Jewelry.Models.DbModels;
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

    public Product GetById(int id)
    {
        return this.productRepository.Get(x => x.Id == id, "ProductImages");
    }
}
