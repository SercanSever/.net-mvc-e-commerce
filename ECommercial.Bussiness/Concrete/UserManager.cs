using ECommercial.Bussiness.Abstract;
using ECommercial.Core.Utilities.Business;
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
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            BusinessRules.Run(CryptoUserPassword(user));
            user.Status = true;
            _userDal.Add(user);
            return new SuccessResult();
        }
        public IDataResult<User> IsLoginSuccess(User user)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var userModel = _userDal.GetAll().Where(x => x.Email == user.Email).FirstOrDefault();
            if (userModel != null && userModel.Status == true)
            {
                if (userModel.PaswordHash == crypto.Compute(user.PaswordHash, userModel.PasswordSalt))
                {
                    return new SuccessDataResult<User>(userModel);
                }
                else
                {
                    return new ErrorDataResult<User>();
                }
            }
            return new ErrorDataResult<User>();
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetById(int productId)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Id == productId));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        private IResult CryptoUserPassword(User user)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var encrypedPassword = crypto.Compute(user.PaswordHash);

            if (user.Id == 0)
            {
                user.PaswordHash = encrypedPassword;
                user.PasswordSalt = crypto.Salt;
            }
            return new SuccessResult();

        }
    }
}
