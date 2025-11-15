using E_Commerce.Service.MappingProfiles;
using E_Commerce.Service.MappingProfiles.Resolvers;
using E_Commerce.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace E_Commerce.Service.DependencyInjections;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<DeliveryMethodNameAsyncResolver>();
        services.AddScoped<DeliveryMethodCostAsyncResolver>();
        services.AddAutoMapper(typeof(OrderProfile).Assembly);
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
