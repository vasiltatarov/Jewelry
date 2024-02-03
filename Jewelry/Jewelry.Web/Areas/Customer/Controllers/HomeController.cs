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
