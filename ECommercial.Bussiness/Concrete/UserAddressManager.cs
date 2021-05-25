using ECommercial.Bussiness.Abstract;
using ECommercial.Core.Utilities.Results;
using ECommercial.DataAccess.Abstract;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Bussiness.Concrete
{
    public class UserAddressManager : IUserAddressService
    {
        private IUserAddressDal _userAddressDal;

        public UserAddressManager(IUserAddressDal userAddressDal)
        {
            _userAddressDal = userAddressDal;
        }

        public IResult Add(UserAddress userAddress)
        {
            _userAddressDal.Add(userAddress);
            return new SuccessResult();
        }

        public IDataResult<List<UserAddress>> GetAll()
        {
            return new SuccessDataResult<List<UserAddress>>(_userAddressDal.GetAll());
        }

        public IDataResult<UserAddress> GetById(int userAddressId)
        {
            return new SuccessDataResult<UserAddress>(_userAddressDal.Get(x => x.Id == userAddressId));
        }

        public IResult Update(UserAddress userAddress)
        {
            _userAddressDal.Update(userAddress);
            return new SuccessResult();
        }
    }
}
