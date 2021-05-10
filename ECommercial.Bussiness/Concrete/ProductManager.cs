using ECommercial.Bussiness.Abstract;
using ECommercial.Bussiness.Constants;
using ECommercial.Core.Utilities.Business;
using ECommercial.Core.Utilities.Results;
using ECommercial.DataAccess.Abstract;
using ECommercial.DataAccess.Context;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Bussiness.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            BusinessRules.Run(SetProductStockStatus(product), StatusDefault(product));
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);
        }
        public IDataResult<List<Product>> GetAllWithPhotos()
        {
            var result = _productDal.GetAll().Distinct().ToList();
            return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.Id == productId));
        }

        public IResult Update(Product product)
        {
            BusinessRules.Run(SetProductStockStatus(product));
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        public IDataResult<List<ProductWithImageDto>> GetProductWithImages()
        {
            using (ECommercialContext context = new ECommercialContext())
            {

                var list = context.Database.SqlQuery<ProductWithImageDto>("select * from Products p inner join(select * from ProductImages where Id in (select t.id from(select ProductId, max(Id) as id from ProductImages group by ProductId) as t)) as pı on p.Id = pı.ProductId inner join Categories c on c.CategoryId = p.CategoryId").ToListAsync().Result;
                return new SuccessDataResult<List<ProductWithImageDto>>(list);
            }

        }
        public IDataResult<List<ProductWithImageDto>> GetProductsWithCategoryId(int id)
        {
            using (ECommercialContext context = new ECommercialContext())
            {
                var list = context.Database.SqlQuery<ProductWithImageDto>($"select * from Products p inner join(select * from ProductImages where Id in (select t.id from(select ProductId, max(Id) as id from ProductImages group by ProductId) as t)) as pı on p.Id = pı.ProductId inner join Categories c on c.CategoryId = p.CategoryId where p.CategoryId = {id}").ToListAsync().Result;
                return new SuccessDataResult<List<ProductWithImageDto>>(list);
            }

        }



        private IResult SetProductStockStatus(Product product)
        {
            if (product.UnitsInStock >= 10)
            {
                product.StockStatus = true;
            }
            else if (product.UnitsInStock > 0 && product.UnitsInStock < 10)
            {
                product.StockStatus = false;
            }
            return new SuccessResult();
        }
        private IResult StatusDefault(Product product)
        {
            product.Status = false;
            return new SuccessResult();
        }


    }
}
