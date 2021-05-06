using ECommercial.Bussiness.Abstract;
using ECommercial.Bussiness.Extensions;
using ECommercial.Core.Utilities.Results;
using ECommercial.DataAccess.Abstract;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommercial.Bussiness.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        private IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public IResult Add(HttpFileCollectionBase files, Product product)
        {
            var path = HttpContext.Current.Server.MapPath("~/Uploads");
            for (int i = 0; i < files.Count; i++)
            {
                var fileName = $"{Guid.NewGuid()}{files[i].GetFileExtension()}";
                var filePath = Path.Combine(path, fileName);
                files[i].SaveAs(filePath);
                var productImage = new ProductImage
                {
                    ProductId = product.Id,
                    Image = fileName,
                    Status = true
                };
                _productImageDal.Add(productImage);
            }
            return new SuccessResult();
        }

        public IResult Delete(ProductImage productImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        public IDataResult<ProductImage> GetById(int producImagetId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(ProductImage productImage)
        {
            throw new NotImplementedException();
        }
    }
}
