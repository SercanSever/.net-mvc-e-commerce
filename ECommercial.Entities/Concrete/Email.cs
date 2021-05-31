using ECommercial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Entities.Concrete
{
    public class Email : IEntity
    {
        public int EmailId { get; set; }
        public string UserEmail { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime EmailDate { get; set; }
    }
}
