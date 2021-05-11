using ECommercial.Core.Utilities.Results;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Bussiness.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
        IDataResult<List<ProductWithImageDto>> GetProductWithImages();
        IDataResult<List<ProductWithImageDto>> GetProductsWithCategoryId(int id);
        IDataResult<ProductWithImageDto> GetProductWithImagesByProductId(int id);
    }
}
