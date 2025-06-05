using AssignedTask.BusinessLogic.Dtos;
using FluentValidation;

namespace AssignedTask.BusinessLogic.DtoValidators
{
    public class UserLoginDtoValidator:AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x =>x.Email)
            .NotEmpty().WithMessage("Email field must not be null!");

            RuleFor(x=>x.Password)
            .NotEmpty().WithMessage("Password field must not be null!");
        }
    }
}