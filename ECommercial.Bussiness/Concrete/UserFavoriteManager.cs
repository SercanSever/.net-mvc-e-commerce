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
    public class UserFavoriteManager : IUserFavoriteService
    {
        private IUserFavoriteDal _userFavoriteDal;

        public UserFavoriteManager(IUserFavoriteDal userFavoriteDal)
        {
            _userFavoriteDal = userFavoriteDal;
        }

        public IDataResult<List<UserFavorite>> GetAll()
        {
            return new SuccessDataResult<List<UserFavorite>>(_userFavoriteDal.GetAll());
        }
    }
}
