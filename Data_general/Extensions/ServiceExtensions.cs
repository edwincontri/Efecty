using Data_general.DataContext;
using Data_general.Interface;
using Data_general.Service;

namespace Data_general.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IDataInterface, DataServicePer>();            
            return services;
        }
    }
}

