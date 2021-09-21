using ECommercial.Bussiness.Abstract;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommercial.UI.Areas.ECommercial.Controllers
{
    public class CartsController : Controller
    {
        private ICartService _cartService;
        private IUserAddressService _userAddressService;
        private IOrderService _orderService;

        public CartsController(ICartService cartService, IUserAddressService userAddressService, IOrderService orderService)
        {
            _cartService = cartService;
            _userAddressService = userAddressService;
            _orderService = orderService;
        }

        public ActionResult Index()
        {
            var cartList = _cartService.GetCart();
            return View(cartList.Data);
        }
        [HttpPost]
        public ActionResult AddCart([Bind(Prefix = "Item1")] Product product)
        {
            if (product.DiscountedPrice != 0)
            {
                product.UnitPrice = product.DiscountedPrice;
                _cartService.AddCart(product);
            }
            else
            {
                _cartService.AddCart(product);
            }
            return RedirectToAction("ProductDetails", "Products", new { @id = product.Id });
        }
        [HttpGet]
        public ActionResult DeleteItem(int Id)
        {
            _cartService.DeleteFromCart(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetCountWithPartial()
        {
            var cartListCount = _cartService.GetCart().Data.Count;
            ViewBag.CartListCount = cartListCount;
            return PartialView("_PartialCartCount");
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddressConfirmation()
        {
            var cartList = _cartService.GetCart();
            var userId = Convert.ToInt32(Session["Id"]);
            var result = _userAddressService.GetByUserId(userId);
            return View(Tuple.Create<UserAddress, List<Product>>(result.Data, cartList.Data));
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cartList = _cartService.GetCart();
            return View(cartList.Data);
        }
        [HttpGet]
        public ActionResult Pay()
        {
            var cartList = _cartService.GetCart();
            var order = new Order();
            foreach (var product in cartList.Data)
            {
                order.ProductId = product.Id;
                order.OrderDate = DateTime.Now;
                order.UserId = Convert.ToInt32(Session["Id"]);
                order.Quantity = product.OrderQuantity;
                _orderService.Add(order);
            }
            _cartService.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}