using ECommercial.Bussiness.Abstract;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ECommercial.UI.Areas.ECommercial.Controllers
{
    public class AuthController : Controller
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            throw new Exception();
        }
        [HttpPost]
        public ActionResult LogIn(User user)
        {
            var result = _userService.IsLoginSuccess(user);
            if (result.Success)
            {
                Session["UserName"] = result.Data.FirstName;
                Session["Id"] = result.Data.Id;
                FormsAuthentication.SetAuthCookie(result.Data.Email, result.Data.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Request.Cookies.Clear();
            Session["UserName"] = null;
            Session["Id"] = null;
            return RedirectToAction("Index");
        }
    }
}