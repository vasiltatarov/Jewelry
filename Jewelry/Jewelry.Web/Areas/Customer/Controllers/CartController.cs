namespace Jewelry.Web.Areas.Customer.Controllers;

[Area(WebConstants.CustomerAreaName)]
[Authorize]
public class CartController : Controller
{
    private readonly IShoppingCartService shoppingCartService;
    private readonly IImageService imageService;

    public CartController(IShoppingCartService shoppingCartService, IImageService imageService)
    {
        this.shoppingCartService = shoppingCartService;
        this.imageService = imageService;
    }

    [BindProperty]
    public ShoppingCartViewModel ShoppingCartViewModel { get; set; }

    public IActionResult Index()
    {
        this.ShoppingCartViewModel = new()
        {
            ShoppingCartList = this.shoppingCartService.GetAllForUser(this.User.GetUserId()),
            OrderHeader = new()
        };

        var images = this.imageService.GetAll();

        foreach (var cart in this.ShoppingCartViewModel.ShoppingCartList)
        {
            cart.ImageUrl = images.FirstOrDefault(x => x.ProductId == cart.Product.Id)?.ImageUrl;
            this.ShoppingCartViewModel.OrderHeader.OrderTotal += cart.Product.Price * cart.Count;
        }

        return View(this.ShoppingCartViewModel);
    }

    public IActionResult Plus(int cartId)
    {
        this.shoppingCartService.Plus(cartId);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Minus(int cartId)
    {
        this.shoppingCartService.Minus(cartId);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Remove(int cartId)
    {
        this.shoppingCartService.Remove(cartId);

        return RedirectToAction(nameof(Index));
    }
}
