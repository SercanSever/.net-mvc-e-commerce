using ECommercial.Bussiness.Abstract;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommercial.UI.Areas.AdministratorArea.Controllers
{
    public class CustomersController : Controller
    {
        private IUserService _userService;
        private IUserAddressService _userAddressService;
        private IOrderDetailService _orderDetailService;
        private ICommentService _commentService;
        private IContactService _contactService;

        public CustomersController(IUserService userService, IUserAddressService userAddressService, IOrderDetailService orderDetailService,ICommentService commentService,IContactService contactService)
        {
            _userService = userService;
            _userAddressService = userAddressService;
            _orderDetailService = orderDetailService;
            _commentService = commentService;
            _contactService = contactService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var result = _userService.GetAll();
            return View(result.Data);
        }
        [HttpGet]
        public ActionResult UserDetails(int Id)
        {
            var userCommentCount = _commentService.GetByUserId(Id).Data.Count;
            ViewBag.userCommentCount = userCommentCount;
            var userOrderCount = _orderDetailService.GetAllOrdersWithUserId(Id).Data.Count;
            ViewBag.userOrderCount = userOrderCount;
            var userMessageCount = _contactService.GetByUserId(Id).Data.Count;
            ViewBag.userMessageCount = userMessageCount;

            var result = _userAddressService.GetByUserId(Id);
            var userResult = _userService.GetById(Id);
            return View(Tuple.Create<UserAddress, User>(result.Data, userResult.Data));
        }
        [HttpGet]
        public ActionResult ShoppingHistory(int Id)
        {
            var result = _orderDetailService.GetAllOrdersWithUserId(Id);
            return View(result.Data);
        }
    }
}