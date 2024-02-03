namespace Jewelry.Web.Areas.Admin.Controllers;

[Area(GlobalConstants.RoleAdmin)]
public class ProductController : Controller
{
    private readonly IProductService productService;
    private readonly ICategoryService categoryService;
    private readonly IImageService imageService;
    private readonly IWebHostEnvironment webHostEnvironment;

    public ProductController(IProductService productService, ICategoryService categoryService, IImageService imageService, IWebHostEnvironment webHostEnvironment)
    {
        this.productService = productService;
        this.categoryService = categoryService;
        this.imageService = imageService;
        this.webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index() => View();

    public IActionResult Upsert(int? id)
    {
        var viewModel = new ProductViewModel
        {
            CategoryList = this.categoryService.GetCategoryList(),
            Product = new()
        };

        if (id.HasValue && id.Value > 0)
        {
            viewModel.Product = this.productService.GetById(id.Value);
        }

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Upsert(ProductViewModel viewModel, IList<IFormFile> files)
    {
        if (!ModelState.IsValid)
        {
            viewModel.CategoryList = this.categoryService.GetCategoryList();

            return View(viewModel);
        }

        if (viewModel.Product.Id == 0)
        {
            this.productService.Add(viewModel.Product);
            TempData["success"] = string.Format(WebConstants.SuccessCreateNotification, nameof(Product));
        }
        else
        {
            this.productService.Update(viewModel.Product);
            TempData["success"] = string.Format(WebConstants.SuccessEditNotification, nameof(Product));
        }

        if (this.imageService.ProcessFiles(files, this.webHostEnvironment.WebRootPath, viewModel.Product.Id) == false)
        {
            TempData["error"] = string.Format(WebConstants.ProcessFilesErrorMessage, nameof(this.imageService.ProcessFiles));
        }

        return RedirectToAction(nameof(Index));
    }

    public IActionResult DeleteImage(int imageId)
    {
        var productId = this.imageService.DeleteImage(this.webHostEnvironment.WebRootPath, imageId);

        if (productId == -1)
        {
            TempData["error"] = string.Format(WebConstants.ProcessFilesErrorMessage, nameof(DeleteImage));
            return RedirectToAction(nameof(Index));
        }
        else
        {
            TempData["success"] = string.Format(WebConstants.SuccessDeleteNotification, nameof(ProductImage));
        }

        return RedirectToAction(nameof(Upsert), new { id = productId });
    }

    #region API Calls

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = this.productService.GetAll();

        return Json(new { data = products });
    }

    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var product = this.productService.GetById(id.Value);

        if (product == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        if (this.imageService.DeleteProductImages(this.webHostEnvironment.WebRootPath, product.Id) == false)
        {
            return Json(new { success = false, message = "Error while deleting images" });
        }

        this.productService.Delete(product);

        return Json(new { success = true, message = "Delete Successful" });
    }

    #endregion
}
