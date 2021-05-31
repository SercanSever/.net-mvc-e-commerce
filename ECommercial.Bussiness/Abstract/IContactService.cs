using ECommercial.Core.Utilities.Results;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Bussiness.Abstract
{
    public interface IContactService
    {
        IResult Add(Contact contact);
        IDataResult<List<Contact>> GetAll();
        IDataResult<Contact> GetById(int Id);
        IDataResult<List<Contact>> GetByUserId(int ıd);
    }
}
