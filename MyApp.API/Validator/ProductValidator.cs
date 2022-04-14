using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MyApp.Domain.Entities;

namespace MyApp.API.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please insert a valid name to Product")
                    .Length(2, 80).WithMessage("Please insert a name with valid size");

            RuleFor(x => x.Price).NotEmpty().WithMessage("You must insert a value to Price");
            RuleFor(x => x.Stock).NotNull().WithMessage("You must insert how much products have in stock ");
            RuleFor(x => x.Image).Length(1, 150).WithMessage("Please insert a valid name");
        }
    }
}
