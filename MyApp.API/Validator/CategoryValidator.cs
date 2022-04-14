using System;
using FluentValidation;
using MyApp.Application.RequestCommand.Categories;

namespace MyApp.API.Validator
{
    public class CategoryValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().OnAnyFailure(request => throw new ApplicationException("Name isn't null"));
        }
    }
}
