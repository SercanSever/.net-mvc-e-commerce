using ECommercial.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommercial.UI.Areas.AdministratorArea.Data
{
    public class CategoryListViewModel
    {
        public List<SelectListItem> GetCategoriesList()
        {
            using (ECommercialContext context = new ECommercialContext())
            {
                var result = from c in context.Categories.Where(x => x.Status == true)
                             select new SelectListItem
                             {
                                 Text = c.CategoryName,
                                 Value = c.CategoryId.ToString()
                             };
                return result.ToList();
            }
        }
    }
}