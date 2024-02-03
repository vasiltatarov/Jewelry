namespace Jewelry.Web.Areas.Admin.Controllers;

using Jewelry.Models.DbModels;

[Area(WebConstants.AdminAreaName)]
[Authorize(Roles = GlobalConstants.RoleAdmin)]
public class CategoryController : Controller
{
    private readonly ICategoryService categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var categories = this.categoryService.GetAll();

        return View(categories);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View(category);
        }

        this.categoryService.Add(category); 

        TempData["success"] = string.Format(WebConstants.SuccessCreateNotification, nameof(Category));

        return RedirectToAction(nameof(Index));
    }
}
