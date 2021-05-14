using ECommercial.Core.DataAccess.EntityFramework;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.DataAccess.Concrete.EntityFramework
{
    public class EfUserFavoritesDal : EntityRepositoryBase<UserFavorites, ECommercialContext>
    {
    }
}
