using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Versta24TestForDevJun.BLL.Services.Abstract;
using Versta24TestForDevJun.BLL.Services.Implementation;
using Versta24TestForDevJun.DAL;

namespace Versta24TestForDevJun.BLL
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterBllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories(configuration);
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
