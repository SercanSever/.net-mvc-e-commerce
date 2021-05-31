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
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(Comment comment)
        {
            comment.Status = false;
            _commentDal.Add(comment);
            return new SuccessResult();
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll());
        }

        public IDataResult<List<Comment>> GetAllWithProductId(int Id)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(x => x.ProductId == Id));
        }

        public IDataResult<Comment> GetById(int commentId)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(x => x.CommentId == commentId));
        }

        public IDataResult<List<Comment>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(x => x.UserId == userId));
        }

        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult();
        }
    }
}
