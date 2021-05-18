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
        public int CategoryId { get; set; }
        public int? UserId { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool StockStatus { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }
        public decimal PercentOfDiscount { get; set; }

    }
}
