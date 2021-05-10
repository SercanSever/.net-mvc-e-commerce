﻿using ECommercial.Bussiness.Abstract;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommercial.UI.Areas.ECommercial.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult Index(string searchFilter = null)
        {
            if (!string.IsNullOrWhiteSpace(searchFilter))
            {
                var categoryResult = _categoryService.GetAll();
                var result = _productService.GetProductWithImages().Data.Where(x => x.Name.Contains(searchFilter));
                return View(Tuple.Create<List<ProductWithImageDto>, List<Category>>(result.ToList(), categoryResult.Data));
            }
            else
            {
                var categoryResult = _categoryService.GetAll();
                var result = _productService.GetProductWithImages();
                return View(Tuple.Create<List<ProductWithImageDto>, List<Category>>(result.Data, categoryResult.Data));
            }
        }
        [HttpGet]
        public ActionResult SortByNewest()
        {
            var categoryResult = _categoryService.GetAll();
            var result = _productService.GetProductWithImages().Data.OrderByDescending(x => x.ProductId);
            return View("Index", Tuple.Create<List<ProductWithImageDto>, List<Category>>(result.ToList(), categoryResult.Data));
        }
        [HttpGet]
        public ActionResult SortByRising()
        {
            var categoryResult = _categoryService.GetAll();
            var result = _productService.GetProductWithImages().Data.OrderBy(x => x.UnitPrice);
            return View("Index", Tuple.Create<List<ProductWithImageDto>, List<Category>>(result.ToList(), categoryResult.Data));

        }
        [HttpGet]
        public ActionResult SortByDecreasing()
        {
            var categoryResult = _categoryService.GetAll();
            var result = _productService.GetProductWithImages().Data.OrderByDescending(x => x.UnitPrice);
            return View("Index", Tuple.Create<List<ProductWithImageDto>, List<Category>>(result.ToList(), categoryResult.Data));
        }
        [HttpGet]
        public ActionResult GetProductsWithCategoryId(int id)
        {
            var categoryResult = _categoryService.GetAll();
            var result = _productService.GetProductsWithCategoryId(id);
            if (result.Success)
            {
                return View("Index", Tuple.Create<List<ProductWithImageDto>, List<Category>>(result.Data, categoryResult.Data));
            }
            throw new Exception();
        }

    }
}