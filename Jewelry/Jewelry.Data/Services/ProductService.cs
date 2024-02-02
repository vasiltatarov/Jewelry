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

    public List<Product> GetAll()
    {
        var products = this.productRepository.GetAll(includeProperties: "Category");

        return products.ToList();
    }
}
