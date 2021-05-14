using ECommercial.Core.DataAccess.EntityFramework;
using ECommercial.DataAccess.Abstract;
using ECommercial.DataAccess.Context;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.DataAccess.Concrete.EntityFramework
{
    public class EfUserFavoriteDal : EntityRepositoryBase<UserFavorite, ECommercialContext>, IUserFavoriteDal
    {
    }
}
