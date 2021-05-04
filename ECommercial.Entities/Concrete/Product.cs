using ECommercial.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Entities.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60)]
        [Column(TypeName = "NVarChar")]
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool StockStatus { get; set; }
        public int PercentOfDiscount { get; set; }
        [StringLength(500)]
        [Column(TypeName = "NVarChar")]
        public string Image { get; set; }
        public bool Status { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
