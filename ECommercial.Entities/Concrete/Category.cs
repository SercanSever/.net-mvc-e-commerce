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
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        [StringLength(60)]
        [Column(TypeName = "NVarChar")]
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
