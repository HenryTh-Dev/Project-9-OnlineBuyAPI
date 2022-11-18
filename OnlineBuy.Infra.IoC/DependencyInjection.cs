using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineBuy.Application.Mappings;
using OnlineBuy.Application.Services;
using OnlineBuy.Application.Services.Interfaces;
using OnlineBuy.Domain.Interfaces.Repositories;
using OnlineBuy.Infra.Data.Context;
using OnlineBuy.Infra.Data.Repositories;

namespace OnlineBuy.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            string databaseConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options =>
                                            options.UseSqlServer(databaseConnection));

            services.AddScoped<IPersonRepository, PersonRespository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }
    }
}
