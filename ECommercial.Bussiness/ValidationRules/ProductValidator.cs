using ECommercial.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Bussiness.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı boş bırakılamaz.");
            RuleFor(x => x.StockStatus).NotEmpty().WithMessage("Stok boş bırakılamaz.");
            RuleFor(x => x.Name).MaximumLength(50).MinimumLength(1).WithMessage("Ürün adı 1 ile 50 karakter arasında olmalıdır.");
        }
    }
}
