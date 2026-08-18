using WebApplicationTutorial.Interfaces;
using WebApplicationTutorial.Security;

namespace WebApplicationTutorial.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
          services.AddScoped<IService, ProductService>();
          services.AddSingleton<SHAHashingService>();
          services.AddSingleton<HMACHashingService>();
          services.AddSingleton<TokenService>();
          services.AddScoped<AuthService>();
            return services;
        }
    }
}
