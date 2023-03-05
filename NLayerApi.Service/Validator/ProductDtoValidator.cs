using FluentValidation;
using NLayerApi.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApi.Service.Validator
{
    public class ProductDtoValidator:AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage($"Boş verilən olnaz !!!");
            RuleFor(x => x.Price).NotNull().InclusiveBetween(1,decimal.MaxValue).WithMessage($"Ən aşağı qiymət 1 olmalıdır");
            RuleFor(x => x.CategoryId).NotNull().NotEmpty().WithMessage($"Boş verilən olnaz !!!");
        }
    }
}
