using ECommercial.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Entities.Concrete
{
    public class Comment : IEntity
    {

        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
