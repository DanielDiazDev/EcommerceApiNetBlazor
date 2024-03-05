using EcommerceNetBlazor.Data.Configurations;
using EcommerceNetBlazor.Data.Repositories.Contracts;
using EcommerceNetBlazor.Data.Repositories.Implementation;
using EcommerceNetBlazor.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceNetBlazor.Data
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(SqlServerConfiguration.BuildConnectionString(configuration));
            });
            // services.AddIdentityCore<User>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentityCore<User>(options =>
            {
                // Configuración de opciones de Identity
            })
            .AddRoles<IdentityRole>() // Agregar soporte para roles
            .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
