using Microsoft.Extensions.DependencyInjection;
using AssignedTask.DataAccess.Repositories.Interfaces;
using AssignedTask.DataAccess.Repositories.Implementations;
using AssignedTask.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace AssignedTask.DataAccess
{
    public static class DALDependancyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IStatesRepository, StatesRepository>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();
            services.AddScoped<ICategoriesRepository,CategoriesRepository>();
            services.AddScoped<IProductsRepository,ProductsRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }

        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var conn = configuration.GetConnectionString("AssignedTaskDbConnection");
            services.AddDbContext<AssignedTaskContext>(q => q.UseNpgsql(conn));
            return services;
        }
    }
}