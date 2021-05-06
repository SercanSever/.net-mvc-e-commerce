using ECommercial.Core.DataAccess.EntityFramework;
using ECommercial.DataAccess.Abstract;
using ECommercial.DataAccess.Context;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EntityRepositoryBase<Product, ECommercialContext>, IProductDal
    {
        public List<ProductWithImageDto> GetProductWithImage()
        {
            using (ECommercialContext context = new ECommercialContext())
            {
                var result = from p in context.Products
                             join pı in context.ProductImages
                             on p.Id equals pı.ProductId
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new ProductWithImageDto
                             {
                                 ProductId = p.Id,
                                 Name = p.Name,
                                 CategoryName = c.Name,
                                 UnitPrice = p.UnitPrice,
                                 UnitsInStock = p.UnitsInStock,
                                 ProductImage = pı.Image
                             };
                return result.ToList();
            }
        }
    }
}
