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
    public class ProductImage : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        [Column(TypeName = "NVarChar")]
        public string Image { get; set; }
        public bool Status { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
