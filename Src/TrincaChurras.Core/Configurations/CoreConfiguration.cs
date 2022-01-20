using Microsoft.Extensions.DependencyInjection;
using TrincaChurras.Core.Interfaces.Services;
using TrincaChurras.Core.Services;

namespace TrincaChurras.Core.Configurations
{
    public static class CoreConfiguration
    {
        public static IServiceCollection AddCoreConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IScheduleService, ScheduleService>();

            return services;
        }
    }
}
