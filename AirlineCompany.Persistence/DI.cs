using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AirlineCompany.Application.Interfaces;

namespace AirlineCompany.Persistence
{
    public static class DI
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDapperContext, DbContext>(sp=>new DbContext(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
