﻿namespace Jewelry.Web.Areas.Customer.Controllers;

[Area(WebConstants.CustomerAreaName)]
[Authorize]
public class CartController : Controller
{
    private readonly IShoppingCartService shoppingCartService;
    private readonly IOrderHeaderService orderHeaderService;
    private readonly IOrderDetailService orderDetailService;

    public CartController(IShoppingCartService shoppingCartService, IOrderHeaderService orderHeaderService, IOrderDetailService orderDetailService)
    {
        this.shoppingCartService = shoppingCartService;
        this.orderHeaderService = orderHeaderService;
        this.orderDetailService = orderDetailService;
    }

    [BindProperty]
    public ShoppingCartViewModel ShoppingCartViewModel { get; set; }

    public IActionResult Index()
    {
        this.ShoppingCartViewModel = new()
        {
            ShoppingCartList = this.shoppingCartService.GetAllForUser(this.User.GetUserId())
        };

        this.shoppingCartService.AddImagesToCarts(this.ShoppingCartViewModel.ShoppingCartList);
        this.ShoppingCartViewModel.OrderHeader.OrderTotal = this.shoppingCartService.CalculateOrderTotal(this.ShoppingCartViewModel.ShoppingCartList);

        return View(this.ShoppingCartViewModel);
    }

    public IActionResult Summary()
    {
        this.ShoppingCartViewModel = new()
        {
            ShoppingCartList = this.shoppingCartService.GetAllForUser(this.User.GetUserId())
        };

        this.shoppingCartService.OrderDetailsForUser(this.ShoppingCartViewModel.OrderHeader, this.User.GetUserId());
        this.ShoppingCartViewModel.OrderHeader.OrderTotal = this.shoppingCartService.CalculateOrderTotal(this.ShoppingCartViewModel.ShoppingCartList);

        return View(this.ShoppingCartViewModel);
    }

    [HttpPost]
    [ActionName("Summary")]
    public IActionResult SummaryPost()
    {
        this.ShoppingCartViewModel.ShoppingCartList = this.shoppingCartService.GetAllForUser(this.User.GetUserId());
        this.ShoppingCartViewModel.OrderHeader.OrderDate = DateTime.Now;
        this.ShoppingCartViewModel.OrderHeader.UserId = this.User.GetUserId();

        this.ShoppingCartViewModel.OrderHeader.PaymentStatus = GlobalConstants.PaymentStatusPending;
        this.ShoppingCartViewModel.OrderHeader.OrderStatus = GlobalConstants.StatusPending;

        this.orderHeaderService.Add(this.ShoppingCartViewModel.OrderHeader);

        foreach (var cart in this.ShoppingCartViewModel.ShoppingCartList)
        {
            var orderDetail = new OrderDetail
            {
                OrderHeaderId = this.ShoppingCartViewModel.OrderHeader.Id,
                ProductId = cart.ProductId,
                Price = cart.ProductPrice,
                Count = cart.Count
            };

            this.orderDetailService.Add(orderDetail);
        }

        // Implement Stripe payment

        return View();
    }

    // ToDo Check if the quantity is more than the existing
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
