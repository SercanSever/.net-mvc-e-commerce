﻿using ECommercial.Bussiness.Abstract;
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
            return View(result.Data);
        }
    }
}