namespace Jewelry.Web.Areas.Customer.Controllers;

[Area(WebConstants.CustomerAreaName)]
[Authorize]
public class CartController : Controller
{
    private readonly IShoppingCartService shoppingCartService;

    public CartController(IShoppingCartService shoppingCartService)
    {
        this.shoppingCartService = shoppingCartService;
    }

    [BindProperty]
    public ShoppingCartViewModel ShoppingCartViewModel { get; set; }

    public IActionResult Index()
    {
        this.ShoppingCartViewModel = new()
        {
            ShoppingCartList = this.shoppingCartService.GetAllForUser(this.User.GetUserId())
        };

        this.ShoppingCartViewModel.OrderHeader.OrderTotal = this.shoppingCartService.CalculateOrderTotal(this.ShoppingCartViewModel.ShoppingCartList);

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
