using ECommercial.Core.Utilities.Results;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Bussiness.Abstract
{
    public interface ICartService
    {
        IDataResult<List<Product>> GetAll();
        IResult DeleteFromCart(int productId);
        IResult AddCart(Product product);
        IDataResult<List<Product>> GetCart();
    }
}
