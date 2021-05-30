using ECommercial.Bussiness.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommercial.UI.Areas.AdministratorArea.Controllers
{
    public class SalesController : Controller
    {
        private IOrderDetailService _orderDetailService;

        public SalesController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        public ActionResult Index()
        {
            var result = _orderDetailService.GetAll();
            return View(result.Data);
        }
    }
}