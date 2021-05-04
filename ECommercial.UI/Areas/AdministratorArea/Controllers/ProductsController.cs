using ECommercial.Bussiness.Abstract;
using ECommercial.Entities.Concrete;
using ECommercial.UI.Areas.AdministratorArea.Data;
using System;
using System.Web.Mvc;

namespace ECommercial.UI.Areas.AdministratorArea.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return View(result.Data);
            }
            throw new Exception(result.Message);
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var categoryListItems = new CategoryListViewModel().GetCategoriesList();
            ViewBag.categoryListItems = categoryListItems;
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            throw new Exception(result.Message);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var categoryListItems = new CategoryListViewModel().GetCategoriesList();
            ViewBag.categoryListItems = categoryListItems;
            var result = _productService.Update(product);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            throw new Exception(result.Message);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            var categoryListItems = new CategoryListViewModel().GetCategoriesList();
            ViewBag.categoryListItems = categoryListItems;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            var categoryListItems = new CategoryListViewModel().GetCategoriesList();
            ViewBag.categoryListItems = categoryListItems;
            _productService.Add(product);
            return RedirectToAction("AddProduct");
        }
        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            var result = _productService.GetById(id);
            result.Data.Status = !result.Data.Status;
            _productService.Update(result.Data);
            return RedirectToAction("Index");
        }

    }
}