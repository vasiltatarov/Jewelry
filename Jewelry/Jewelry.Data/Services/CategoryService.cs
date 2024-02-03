namespace Jewelry.Data.Services;

using Jewelry.Data.Repository.IRepository;
using Jewelry.Data.Services.IServices;
using Jewelry.Models.DbModels;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public void Update(Category category)
    {
        this.categoryRepository.Update(category);
        this.categoryRepository.Save();
    }

    public void Delete(int id)
    {
        var category = this.GetById(id);

        this.categoryRepository.Remove(category);
        this.categoryRepository.Save();
    }

    public List<Category> GetAll()
    {
        return this.categoryRepository.GetAll().OrderBy(x => x.DisplayOrder).ToList();
    }

    public Category GetById(int id)
    {
        return this.categoryRepository.Get(x => x.Id == id);
    }

    public List<SelectListItem> GetCategoryList()
    {
        return this.categoryRepository
            .GetAll()
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            })
            .ToList();
    }
}
