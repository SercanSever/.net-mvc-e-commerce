using ECommercial.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        [Key]
        public int OrderDetailıd { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int? OrderQuantity { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal? TotalPaymant { get; set; }
    }
}
