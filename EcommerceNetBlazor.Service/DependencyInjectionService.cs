using EcommerceNetBlazor.Service.Contracts;
using EcommerceNetBlazor.Service.Implementations;
using AutoMapper;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EcommerceNetBlazor.Util;
using Microsoft.AspNetCore.Identity;
using EcommerceNetBlazor.Model;

namespace EcommerceNetBlazor.Service
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddHttpContextAccessor();
            services.AddScoped<SignInManager<User>>();
            services.AddScoped<UserManager<User>>();
            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddAutoMapper(typeof(MapperProfile));

            return services;
        }
    }
}
