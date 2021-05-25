﻿using ECommercial.Bussiness.Abstract;
using ECommercial.Core.Utilities.Results;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommercial.UI.Areas.ECommercial.Controllers
{

    public class UsersController : Controller
    {
        private IUserService _userService;
        private IUserFavoriteService _userFavoriteService;
        private IProductService _productService;
        private IUserAddressService _userAddressService;

        public UsersController(IUserService userService, IUserFavoriteService userFavoriteService, IProductService productService, IUserAddressService userAddressService)
        {
            _userService = userService;
            _userFavoriteService = userFavoriteService;
            _productService = productService;
            _userAddressService = userAddressService;

        }
        [Authorize]
        [HttpGet]
        public ActionResult UserFavorites()
        {
            var result = _userFavoriteService.GetAll().Data.Where(x => x.UserId == Convert.ToInt32(Session["Id"])).ToList();
            ViewData["Count"] = result.Count;
            return View(result);
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddFavorite(int id)
        {
            var product = _productService.GetById(id);
            var userId = Convert.ToInt32(Session["Id"]);
            var userfavorites = new UserFavorite
            {
                ProductId = product.Data.Id,
                UserId = userId,
                Status = true
            };
            var result = _userFavoriteService.Add(userfavorites);
            if (result.Success)
            {
                return RedirectToAction("Index", "Products");
            }
            return RedirectToAction("UserFavorites");
        }
        [HttpGet]
        public ActionResult RemoveFavorite(int id)
        {
            var result = _userFavoriteService.GetById(id);
            //result.Data.Status = false;
            _userFavoriteService.Delete(result.Data);
            return RedirectToAction("UserFavorites", result);
        }
        [HttpGet]
        public ActionResult GetCountWithPartial()
        {
            var result = _userFavoriteService.GetAll().Data.Where(x => x.UserId == Convert.ToInt32(Session["Id"])).ToList();
            ViewBag.Count = result.Count;
            return PartialView("_PartialFavoriteCount");
        }
        [Authorize]
        [HttpGet]
        public ActionResult UserAccount()
        {
            var userId = Convert.ToInt32(Session["Id"]);
            var result = _userAddressService.GetById(userId);
            return View(result.Data);
        }
        [Authorize]
        [HttpGet]
        public ActionResult UpdateAddress(int Id)
        {
            var result = _userAddressService.GetById(Id);
            return View(result.Data);
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateAddress(UserAddress userAddress)
        {
            var result = _userAddressService.Update(userAddress);
            if (result.Success)
            {
                return RedirectToAction("UserAccount");
            }
            throw new Exception();
        }
    }
}