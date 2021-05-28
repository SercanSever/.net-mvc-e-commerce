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

        public CustomersController(IUserService userService, IUserAddressService userAddressService)
        {
            _userService = userService;
            _userAddressService = userAddressService;
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
            var result = _userAddressService.GetByUserId(Id);
            var userResult = _userService.GetById(Id);
            return View(Tuple.Create<UserAddress,User>(result.Data,userResult.Data));
        }
    }
}