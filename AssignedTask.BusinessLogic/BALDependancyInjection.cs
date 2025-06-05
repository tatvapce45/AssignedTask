using Microsoft.Extensions.DependencyInjection;
using AssignedTask.BusinessLogic.Services.Interfaces;
using AssignedTask.BusinessLogic.Services.Implementations;
using AssignedTask.BusinessLogic.Helpers;
namespace AssignedTask.BusinessLogic
{
    public static class BALDependancyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }

        public static IServiceCollection AddJwtTokenGeneratorHelper(this IServiceCollection services)
        {
            services.AddScoped<JwtTokenGeneratorHelper>();
            return services;
        }
    }
}