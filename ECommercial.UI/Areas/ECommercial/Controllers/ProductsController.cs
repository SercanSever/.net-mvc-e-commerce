using ECommercial.Bussiness.Abstract;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommercial.UI.Areas.ECommercial.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult Index(string searchFilter = null)
        {
            if (!string.IsNullOrWhiteSpace(searchFilter))
            {
                var result = _productService.GetProductWithImages().Data.Where(x => x.Name.Contains(searchFilter));
                return View(result.ToList());
            }
            else
            {
                var result = _productService.GetProductWithImages();
                return View(result.Data);
            }
        }
        [HttpGet]
        public ActionResult SortByNewest()
        {
            var result = _productService.GetProductWithImages().Data.OrderByDescending(x => x.ProductId);
            return View("Index", result.ToList());
        }
        [HttpGet]
        public ActionResult SortByRising()
        {
            var result = _productService.GetProductWithImages().Data.OrderBy(x => x.UnitPrice);
            return View("Index", result.ToList());

        }
        [HttpGet]
        public ActionResult SortByDecreasing()
        {
            var result = _productService.GetProductWithImages().Data.OrderByDescending(x => x.UnitPrice);
            return View("Index", result.ToList());
        }

    }
}