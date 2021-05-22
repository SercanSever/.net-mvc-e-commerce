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
            return View();
        }
        [HttpPost]
        public ActionResult AddCart([Bind(Prefix = "Item1")] Product product)
        {
            _cartService.AddCart(product);
            return RedirectToAction("ProductDetails", "Products", new { @id = product.Id });
        }
    }
}