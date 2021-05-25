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

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public ActionResult Index()
        {
            var cartList = _cartService.GetCart();
            return View(cartList.Data);
        }
        [HttpPost]
        public ActionResult AddCart([Bind(Prefix = "Item1")] Product product)
        {
            _cartService.AddCart(product);
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
    }
}