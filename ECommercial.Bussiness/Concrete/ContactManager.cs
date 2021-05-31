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
    public class ContactManager : IContactService
    {
        private IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IResult Add(Contact contact)
        {
            _contactDal.Add(contact);
            return new SuccessResult();
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll());
        }

        public IDataResult<Contact> GetById(int Id)
        {
            return new SuccessDataResult<Contact>(_contactDal.Get(x => x.ContactId == Id));
        }

        public IDataResult<List<Contact>> GetByUserId(int ıd)
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(x => x.UserId == ıd));
        }
    }
}
