using ECommercial.Bussiness.Abstract;
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
    public class UserFavoriteManager : IUserFavoriteService
    {
        private IUserFavoriteDal _userFavoriteDal;

        public UserFavoriteManager(IUserFavoriteDal userFavoriteDal)
        {
            _userFavoriteDal = userFavoriteDal;
        }

        public IResult Add(UserFavorite userFavorite)
        {
            var result = _userFavoriteDal.Get(x => x.ProductId == userFavorite.ProductId);
            if (result != null)
            {
                return new ErrorResult();
            }
            _userFavoriteDal.Add(userFavorite);
            return new SuccessResult();
        }

        public IResult Delete(UserFavorite userFavorite)
        {
            _userFavoriteDal.Delete(userFavorite);
            return new SuccessResult();
        }

        public IDataResult<List<ProductWithImageDto>> GetAll()
        {
            using (ECommercialContext context = new ECommercialContext())
            {

                var list = context.Database.SqlQuery<ProductWithImageDto>("select * from Products p inner join(select * from ProductImages where Id in(select t.id from(select ProductId, max(Id) as id from ProductImages group by ProductId) as t)) as pı on p.Id = pı.ProductId inner join UserFavorites uf on uf.ProductId = p.Id where uf.Status = 'True'").ToListAsync().Result;
                return new SuccessDataResult<List<ProductWithImageDto>>(list);
            }
        }
        public IDataResult<UserFavorite> GetById(int id)
        {
            return new SuccessDataResult<UserFavorite>(_userFavoriteDal.Get(x => x.ProductId == id));
        }

        public IResult Update(UserFavorite userFavorite)
        {
            _userFavoriteDal.Update(userFavorite);
            return new SuccessResult();
        }
    }
}
