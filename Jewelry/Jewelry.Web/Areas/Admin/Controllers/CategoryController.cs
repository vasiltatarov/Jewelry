namespace Jewelry.Web.Areas.Admin.Controllers;

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
}
