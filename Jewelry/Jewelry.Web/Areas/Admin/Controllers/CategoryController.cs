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
        return View(this.categoryService.GetAll());
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

    public IActionResult Update(int id)
    {
        var category = this.categoryService.GetById(id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost]
    public IActionResult Update(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View(category);
        }

        this.categoryService.Update(category);

        TempData["success"] = string.Format(WebConstants.SuccessEditNotification, nameof(Category));

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var category = this.categoryService.GetById(id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int id)
    {
        this.categoryService.Delete(id);

        TempData["success"] = string.Format(WebConstants.SuccessDeleteNotification, nameof(Category));

        return RedirectToAction("Index");
    }
}
