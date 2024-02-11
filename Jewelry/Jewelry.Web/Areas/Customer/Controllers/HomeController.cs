namespace Jewelry.Web.Areas.Customer.Controllers;

[Area(WebConstants.CustomerAreaName)]
public class HomeController : Controller
{
    private readonly IProductService productService;
    private readonly IShoppingCartService shoppingCartService;

    public HomeController(IProductService productService, IShoppingCartService shoppingCartService)
    {
        this.productService = productService;
        this.shoppingCartService = shoppingCartService;
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

        var viewModel = new ProductDetailsPageViewModel
        {
            Product = product,
            Count = 1,
            Availability = this.productService.GetProductAvailability(product)
        };

        return View(viewModel);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Details(ProductDetailsPageViewModel viewModel)
    {
        if (this.productService.HasQuantity(viewModel.Product.Id, viewModel.Count) == false)
        {
            var product = this.productService.GetById(viewModel.Product.Id, "Category,ProductImages");
            viewModel.Product = product;
            viewModel.Count = product.Quantity;
            viewModel.Availability = this.productService.GetProductAvailability(product);

            TempData[WebConstants.NotEnoughQuantityKey] = string.Format(WebConstants.NotEnoughQuantityMessage, product.Quantity);

            return View(viewModel);
        }

        this.shoppingCartService.AddToCart(viewModel.Product.Id, this.User.GetUserId(), viewModel.Count);

        TempData["success"] = WebConstants.AddToCartNotification;

        return RedirectToAction(nameof(Index));
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
