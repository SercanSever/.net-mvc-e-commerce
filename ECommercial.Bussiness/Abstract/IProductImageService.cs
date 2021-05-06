using ECommercial.Core.Utilities.Results;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommercial.Bussiness.Abstract
{
    public interface IProductImageService
    {
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<ProductImage> GetById(int producImagetId);
        IResult Add(HttpFileCollectionBase files, Product product);
        IResult Update(ProductImage productImage);
        IResult Delete(ProductImage productImage);
    }
}
