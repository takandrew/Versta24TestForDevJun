using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Versta24TestForDevJun.DAL.DataAccess.Abstract;
using Versta24TestForDevJun.DAL.DataAccess.Implementation;
using Versta24TestForDevJun.DAL.DataContext;
using Versta24TestForDevJun.DAL.Entities;

namespace Versta24TestForDevJun.DAL
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository<Order>, EFRepository<Order>>();
            services.AddEntityFrameworkNpgsql().AddDbContext<DeliveryContext>(options =>
            {
                //options.UseNpgsql(configuration.GetConnectionString("DeliveryDb"));
                options.UseNpgsql(configuration.GetConnectionString("DeliveryDB"));
            });
            return services;
        }
    }
}
