namespace Jewelry.Data.Services;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Data.Services.IServices;
using Jewelry.Models.DbModels;
using System.Collections.Generic;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public void Add(Category category)
    {
        this.categoryRepository.Add(category);
        this.categoryRepository.Save();
    }

    public List<Category> GetAll()
    {
        var categories = this.categoryRepository.GetAll().OrderBy(x => x.DisplayOrder).ToList();

        return categories;
    }
}
