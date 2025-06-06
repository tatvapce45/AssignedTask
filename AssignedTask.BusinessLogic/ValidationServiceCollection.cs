using AssignedTask.BusinessLogic.Dtos;
using AssignedTask.BusinessLogic.DtoValidators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AssignedTask.BusinessLogic
{
    public static class ValidationServiceCollection
    {
        public static IServiceCollection AddValidationServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserRegistrationDto>, UserRegistrationDtoValidator>();
            services.AddTransient<IValidator<UserLoginDto>,UserLoginDtoValidator>();
            services.AddTransient<IValidator<ProductsRequestDto>,ProductsRequestDtoValidator>();
            return services;
        }
    }
}
