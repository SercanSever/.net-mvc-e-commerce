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
    public class HomeController : Controller
    {
        private ICategoryService _categoryService;
        private IProductService _productService;

        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var categories = _categoryService.GetAll().Data.Where(x=>x.Status == true).ToList();
            var products = _productService.GetProductWithImages().Data.Where(x=>x.Status == true).ToList();
            return View(Tuple.Create<List<Category>, List<ProductWithImageDto>>(categories, products));
        }
    }
}