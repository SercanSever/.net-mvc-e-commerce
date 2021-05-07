using ECommercial.Core.DataAccess.EntityFramework;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
