using AssignedTask.BusinessLogic.Dtos;
using FluentValidation;

namespace AssignedTask.BusinessLogic.DtoValidators
{
    public class ProductsRequestDtoValidator:AbstractValidator<ProductsRequestDto>
    {
        public ProductsRequestDtoValidator()
        {
            RuleFor(x =>x.CategoryId)
            .NotEmpty().WithMessage("Category Id is required!")
            .GreaterThan(0).WithMessage("Category Id must be greater than 0");

            RuleFor(x =>x.PageNumber)
            .NotEmpty().WithMessage("Page number is required!")
            .GreaterThan(0).WithMessage("Page number must be greater than 0");

            RuleFor(x =>x.PageSize)
            .NotEmpty().WithMessage("Page size is required!")
            .GreaterThan(0).WithMessage("Page size must be greater than 0");
        }
    }
}