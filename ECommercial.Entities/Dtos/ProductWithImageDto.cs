using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Entities.Dtos
{
    public class ProductWithImageDto
    {
        public int ProductId { get; set; }
        public string ProductImage { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
