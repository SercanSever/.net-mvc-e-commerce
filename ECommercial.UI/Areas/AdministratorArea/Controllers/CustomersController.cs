using ECommercial.Bussiness.Abstract;
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

        public CustomersController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            var result = _userService.GetAll();
            return View(result.Data);
        }
    }
}