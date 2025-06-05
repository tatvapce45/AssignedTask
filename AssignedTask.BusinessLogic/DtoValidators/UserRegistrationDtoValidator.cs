using FluentValidation;
using AssignedTask.BusinessLogic.Dtos;

namespace AssignedTask.BusinessLogic.DtoValidators
{
    public class UserRegistrationDtoValidator : AbstractValidator<UserRegistrationDto>
    {
        public UserRegistrationDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Firstname field must not be null!");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Lastname field must not be null!");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username field must not be null!");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email field must not be null!")
                .EmailAddress().WithMessage("Please enter valid email address!");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address field must not be null!");

            RuleFor(x => x.Zipcode)
                .NotEmpty().WithMessage("Zipcode field must not be null!")
                .Matches(@"^\d{6}$").WithMessage("Zipcode must be exactly 6 digits with no characters.");

            RuleFor(x => x.MobileNo)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{10}$").WithMessage("Phone number must be exactly 10 digits with no characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("New Password field must not be null!")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Password must contain at least 1 uppercase, 1 lowercase, 1 number, and 1 special character.");

            RuleFor(x => x.CountryId)
                .NotEmpty().WithMessage("Country field must not be null!");

            RuleFor(x => x.StateId)
                .NotEmpty().WithMessage("State field must not be null!");

            RuleFor(x => x.CityId)
                .NotEmpty().WithMessage("City field must not be null!");
        }
    }
}
