using ECommercial.Bussiness.Abstract;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommercial.UI.Areas.AdministratorArea.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private IUserService _userService;
        private ICommentService _commentService;

        public HomeController(IProductService productService, IUserService userService, ICommentService commentService)
        {
            _productService = productService;
            _userService = userService;
            _commentService = commentService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var productCount = _productService.GetAll().Data.Count;
            var commentCount = _commentService.GetAll().Data.Count;
            ViewBag.productCount = productCount;
            ViewBag.commentCount = commentCount;

            var users = _userService.GetAll().Data.OrderByDescending(x => x.Id).ToList(); ;
            var products = _productService.GetProductWithImages().Data.OrderByDescending(x => x.ProductId).ToList();
            return View(Tuple.Create<List<ProductWithImageDto>, List<User>>(products, users));
        }
    }
}