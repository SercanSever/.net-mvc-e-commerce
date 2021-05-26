using ECommercial.Bussiness.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommercial.UI.Areas.AdministratorArea.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var result = _commentService.GetAll();
            return View(result.Data);
        }
        [HttpGet]
        public ActionResult ApprovedComments()
        {
            var result = _commentService.GetAll().Data.Where(x => x.Status == true);
            return View(result.ToList());
        }
        [HttpGet]
        public ActionResult ChangeStatus(int Id)
        {
            var result = _commentService.GetById(Id);
            result.Data.Status = !result.Data.Status;
            _commentService.Update(result.Data);
            return RedirectToAction("Index");
        }

    }
}