using ECommercial.Core.Utilities.Results;
using ECommercial.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Bussiness.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAllWithProductId(int Id);
        IDataResult<Comment> GetById(int commentId);
        IResult Add(Comment comment);
        IDataResult<List<Comment>> GetAll();
        IResult Update(Comment comment);
    }
}
