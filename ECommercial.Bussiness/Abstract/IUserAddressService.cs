using ECommercial.Core.Utilities.Results;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Bussiness.Abstract
{
    public interface IUserAddressService
    {
        IDataResult<List<UserAddress>> GetAll();
        IDataResult<UserAddress> GetById(int userAddressId);
        IResult Add(UserAddress userAddress);
        IResult Update(UserAddress userAddress);
        IDataResult<UserAddress> GetByUserId(int userAddressId);
    }
}
