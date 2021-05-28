using ECommercial.Bussiness.Abstract;
using ECommercial.Core.CrossCuttingConcerns.Caching;
using ECommercial.Core.Utilities.Results;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommercial.Bussiness.Concrete
{
    public class CartManager : ICartService
    {
        private IProductService _productService;
        private ICacheManager _cacheManager;

        public CartManager(IProductService productService, ICacheManager cacheManager)
        {
            _productService = productService;
            _cacheManager = cacheManager;
        }

        public IDataResult<List<Product>> GetCart()
        {
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            var cartList = new List<Product>();
            if (_cacheManager.IsAdd(ip))
            {
                cartList = _cacheManager.Get<List<Product>>(ip);
                return new SuccessDataResult<List<Product>>(cartList);
            }
            return new ErrorDataResult<List<Product>>(cartList);
        }

        public IResult AddCart(Product product)
        {
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            var productModel = _productService.GetById(product.Id);
            if (product.OrderQuantity == 0)
            {
                return new ErrorResult();
            }
            productModel.Data.OrderQuantity = product.OrderQuantity;
            var cartList = new List<Product>();
            if (_cacheManager.IsAdd(ip))
            {
                cartList = _cacheManager.Get<List<Product>>(ip);
                var productControl = cartList.FirstOrDefault(x => x.Id == product.Id);
                if (productControl == null)
                {
                    cartList.Add(productModel.Data);
                }
                else
                {
                    cartList.Remove(productControl);
                    productControl.OrderQuantity += product.OrderQuantity;
                    cartList.Add(productControl);
                }
                _cacheManager.Add(ip, cartList);
                return new SuccessResult();
            }
            cartList.Add(productModel.Data);
            _cacheManager.Add(ip, cartList);
            return new SuccessResult();
        }

        public IResult DeleteFromCart(int productId)
        {
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (_cacheManager.IsAdd(ip))
            {
                var cartList = _cacheManager.Get<List<Product>>(ip);
                cartList.Remove(cartList.First(x => x.Id == productId));
            }
            return new SuccessResult();
        }


        public IDataResult<List<Product>> GetAll()
        {
            string key = "products";
            if (_cacheManager.IsAdd(key))
            {
                return new SuccessDataResult<List<Product>>(_cacheManager.Get<List<Product>>(key));
            }
            var list = _productService.GetAll();
            _cacheManager.Add(key, list);
            return new SuccessDataResult<List<Product>>(list.Data);
        }

        public IResult Clear()
        {
            _cacheManager.Clear();
            return new SuccessResult();
        }
    }
}
