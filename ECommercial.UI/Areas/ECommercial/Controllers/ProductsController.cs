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
    public class ProductsController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private ICommentService _commentService;

        public ProductsController(IProductService productService, ICategoryService categoryService, ICommentService commentService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _commentService = commentService;
        }
        [HttpGet]
        public ActionResult Index(string searchFilter = null)
        {
            if (!string.IsNullOrWhiteSpace(searchFilter))
            {
                var categoryResult = _categoryService.GetAll().Data.Where(x => x.Status == true).ToList();
                var result = _productService.GetProductWithImages().Data.Where(x => x.Name.Contains(searchFilter)).Where(x => x.Status == true).ToList();
                return View(Tuple.Create<List<ProductWithImageDto>, List<Category>>(result.ToList(), categoryResult));
            }
            else
            {
                var categoryResult = _categoryService.GetAll().Data.Where(x => x.Status == true).ToList();
                var result = _productService.GetProductWithImages().Data.Where(x => x.Status == true).ToList();
                return View(Tuple.Create<List<ProductWithImageDto>, List<Category>>(result, categoryResult));
            }
        }
        [HttpGet]
        public ActionResult SortByNewest()
        {
            var categoryResult = _categoryService.GetAll().Data.Where(x => x.Status == true).ToList();
            var result = _productService.GetProductWithImages().Data.OrderByDescending(x => x.ProductId).Where(x => x.Status == true).ToList();
            return View("Index", Tuple.Create<List<ProductWithImageDto>, List<Category>>(result, categoryResult));
        }
        [HttpGet]
        public ActionResult SortByOldest()
        {
            var categoryResult = _categoryService.GetAll().Data.Where(x => x.Status == true).ToList();
            var result = _productService.GetProductWithImages().Data.OrderBy(x=>x.ProductId).Where(x => x.Status == true).ToList();
            return View("Index", Tuple.Create<List<ProductWithImageDto>, List<Category>>(result, categoryResult));
        }
        [HttpGet]
        public ActionResult SortByRising()
        {
            var categoryResult = _categoryService.GetAll().Data.Where(x => x.Status == true).ToList();
            var result = _productService.GetProductWithImages().Data.OrderBy(x => x.UnitPrice).Where(x => x.Status == true).ToList();
            return View("Index", Tuple.Create<List<ProductWithImageDto>, List<Category>>(result, categoryResult));

        }
        [HttpGet]
        public ActionResult SortByDecreasing()
        {
            var categoryResult = _categoryService.GetAll().Data.Where(x => x.Status == true).ToList();
            var result = _productService.GetProductWithImages().Data.OrderByDescending(x => x.UnitPrice).Where(x => x.Status == true).ToList();
            return View("Index", Tuple.Create<List<ProductWithImageDto>, List<Category>>(result, categoryResult));
        }
      
        [HttpGet]
        public ActionResult GetProductsWithCategoryId(int id)
        {
            var categoryResult = _categoryService.GetAll().Data.Where(x => x.Status == true).ToList();
            var result = _productService.GetProductsWithCategoryId(id).Data.Where(x => x.Status == true).ToList();
            return View("Index", Tuple.Create<List<ProductWithImageDto>, List<Category>>(result, categoryResult));
        }
        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            var categoryResult = _categoryService.GetAll().Data.Where(x => x.Status == true).ToList();
            var productResult = _productService.GetById(id);
            var productsByCategoryId = _productService.GetProductsWithCategoryId(productResult.Data.CategoryId).Data.Where(x => x.Status == true).ToList();
            Tuple<Product, List<Category>, List<ProductWithImageDto>, Comment> tuple = new Tuple<Product, List<Category>, List<ProductWithImageDto>, Comment>(productResult.Data, categoryResult, productsByCategoryId, new Comment());
            var count = _commentService.GetAllWithProductId(id).Data.Where(x => x.Status == true).ToList().Count;
            ViewBag.CommentCount = count;
            return View(tuple);
        }
        [HttpPost]
        public ActionResult AddComment([Bind(Prefix = "Item4")] Comment comment, [Bind(Prefix = "Item1")] Product product)
        {
            comment.UserId = Convert.ToInt32(Session["Id"]);
            comment.ProductId = product.Id;
            comment.Date = DateTime.Now;
            _commentService.Add(comment);
            return RedirectToAction("ProductDetails", new { @id = comment.ProductId });
        }
        [HttpGet]
        public ActionResult ListOfComments(int Id)
        {
            var result = _commentService.GetAllWithProductId(Id).Data;
            return PartialView("_PartialCommentList", result);
        }
        [HttpGet]
        public ActionResult DiscountedProducts()
        {
            var result = _productService.GetProductWithImages().Data.Where(x => x.DiscountedPrice != 0).ToList();
            return PartialView("_PartialDiscounts", result);
        }

    }
}