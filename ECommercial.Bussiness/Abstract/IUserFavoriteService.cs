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
    public interface IUserFavoriteService
    {
        IDataResult<List<ProductWithImageDto>> GetAll();
        IResult Add(UserFavorite userFavorite);
        IResult Update(UserFavorite userFavorite);
        IResult Delete(UserFavorite userFavorite);
        IDataResult<UserFavorite> GetById(int id);

    }
}
