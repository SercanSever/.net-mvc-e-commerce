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
            var model = new User();
            model.Email = CheckCookie();
            return View("Index", model);
        }
        private string CheckCookie()
        {
            if (Request.Cookies.Get("cooky") != null)
            {
                return Request.Cookies["cooky"].Value;
            }
            return string.Empty;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(User user, bool? rememberMe)
        {

            var result = _userService.IsLoginSuccess(user);
            if (result.Success)
            {
                Session["UserName"] = result.Data.FirstName;
                Session["Email"] = result.Data.Email;
                Session["Id"] = result.Data.Id;
                FormsAuthentication.SetAuthCookie(user.Email, true);
            }
            else
            {
                ViewBag.warning = "Email veya Şifreniz Hatalı !";
            }
            if (rememberMe == true)
            {
                HttpCookie httpCookie = new HttpCookie("cooky");
                httpCookie.Value = user.Email;
                httpCookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(httpCookie);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            HttpContext.Session.Abandon();
            return RedirectToAction("Index");
        }
    }

}
