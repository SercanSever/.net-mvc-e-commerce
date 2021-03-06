using ECommercial.Bussiness.Abstract;
using ECommercial.Core.Utilities.Results;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommercial.UI.Areas.AdministratorArea.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var result = _categoryService.GetAll();
            if (result.Success)
            {
                return View(result.Data);
            }
            throw new Exception(result.Message);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (Request.Files.Count > 0 && !string.IsNullOrWhiteSpace(Request.Files[0].FileName))
            {
                string path = Server.MapPath("~/Uploads");
                string fileName = Guid.NewGuid().ToString();
                FileInfo info = new FileInfo(Request.Files[0].FileName);
                fileName = $"{fileName}{info.Extension}";
                path = Path.Combine(path, fileName);
                Request.Files[0].SaveAs(path);
                category.CategoryImage = fileName;
            }
            else
            {
                category.CategoryImage = "no-image-icon-4.png";
            }
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return RedirectToAction("AddCategory");
            }
            throw new Exception(result.Message);
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var result = _categoryService.GetById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            throw new Exception(result.Message);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            if (Request.Files.Count > 0 && !string.IsNullOrWhiteSpace(Request.Files[0].FileName))
            {
                string path = Server.MapPath("~/Uploads");
                string fileName = Guid.NewGuid().ToString();
                FileInfo info = new FileInfo(Request.Files[0].FileName);
                fileName = $"{fileName}{info.Extension}";
                path = Path.Combine(path, fileName);
                Request.Files[0].SaveAs(path);
                category.CategoryImage = fileName;
            }
            var result = _categoryService.Update(category);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            throw new Exception(result.Message);
        }
        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            var result = _categoryService.GetById(id);
            result.Data.Status = !result.Data.Status;
            _categoryService.Update(result.Data);
            return RedirectToAction("Index");
        }
    }
}