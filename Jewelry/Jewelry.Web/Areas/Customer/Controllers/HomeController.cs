namespace Jewelry.Web.Areas.Customer.Controllers;

[Area(WebConstants.CustomerAreaName)]
public class HomeController : Controller
{
    private readonly IProductService productService;

    public HomeController(IProductService productService)
    {
        this.productService = productService;
    }

    public IActionResult Index()
    {
        var products = this.productService.GetAll("Category,ProductImages");

        return View(products);
    }

    public IActionResult Details(int productId)
    {
        var product = this.productService.GetById(productId, "Category,ProductImages");

        if (product == null)
        {
            return NotFound();
        }

        var viewModel = new ShoppingCartViewModel
        {
            Product = product,
            Count = 1,
            Availability = this.productService.GetProductAvailability(product)
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
