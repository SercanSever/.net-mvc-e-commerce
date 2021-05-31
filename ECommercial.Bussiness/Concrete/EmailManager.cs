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
    public class EmailManager : IEmailService
    {
        private IEmailDal _emmailDal;

        public EmailManager(IEmailDal emmailDal)
        {
            _emmailDal = emmailDal;
        }

        public IResult Add(Email email)
        {
            _emmailDal.Add(email);
            return new SuccessResult();
        }

        public IDataResult<List<Email>> GetAll()
        {
            return new SuccessDataResult<List<Email>>(_emmailDal.GetAll());
        }
    }
}
