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
        private IOrderDetailService _orderDetailService;

        public HomeController(IProductService productService, IUserService userService, ICommentService commentService, IOrderDetailService orderDetailService)
        {
            _productService = productService;
            _userService = userService;
            _commentService = commentService;
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var productCount = _productService.GetAll().Data.Count;
            var commentCount = _commentService.GetAll().Data.Count;
            ViewBag.productCount = productCount;
            ViewBag.commentCount = commentCount;

            var orderDetails = _orderDetailService.GetAll().Data.OrderByDescending(x => x.OrderId).Take(10).ToList();
            var users = _userService.GetAll().Data.OrderByDescending(x => x.Id).ToList();
            var products = _productService.GetProductWithImages().Data.OrderByDescending(x => x.ProductId).Take(5).ToList();
            return View(Tuple.Create<List<ProductWithImageDto>, List<User>, List<OrderDetail>>(products, users, orderDetails));
        }
        [HttpGet]
        public ActionResult OnlineUsers()
        {
            ViewBag.onlineUsers = HttpContext.Application["OnlineUsers"].ToString();
            return PartialView("_PartialOnlineUsers", ViewBag.onlineUsers);
        }
        [HttpGet]
        public ActionResult CommentCount()
        {
            ViewBag.commentCount = _commentService.GetAll().Data.Count;
            return PartialView("_PartialCommentCount", ViewBag.commentCount);
        }
        [HttpGet]
        public ActionResult OrderCount()
        {
            ViewBag.orderCount = _orderDetailService.GetAll().Data.Count;
            return PartialView("_PartialOrderCount", ViewBag.orderCount);
        }
        [HttpGet]
        public ActionResult UserCount()
        {
            ViewBag.userCount = _userService.GetAll().Data.Count;
            return PartialView("_PartialUserCount", ViewBag.userCount);
        }
    }
}