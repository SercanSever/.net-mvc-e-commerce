using ECommercial.Core.DataAccess.EntityFramework;
using ECommercial.DataAccess.Abstract;
using ECommercial.DataAccess.Context;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EntityRepositoryBase<Product, ECommercialContext>, IProductDal
    {
       
    }
}
