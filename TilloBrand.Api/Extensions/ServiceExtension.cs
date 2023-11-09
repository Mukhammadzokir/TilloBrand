using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using TilloBrand.Data.IRepositories;
using TilloBrand.Data.Repositories;
using TilloBrand.Service.Interfaces;
using TilloBrand.Service.Mappings;
using TilloBrand.Service.Services;

namespace TilloBrand.Api.Extensions
{
    public static class ServiceExtension 
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAutoMapper(typeof(MappingProfile)); // Register your mapping profile
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IMarketService, MarketService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
        }

    }
}
