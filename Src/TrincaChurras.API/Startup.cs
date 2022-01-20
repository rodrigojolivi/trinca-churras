using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrincaChurras.API.Configurations;
using TrincaChurras.Core.Configurations;
using TrincaChurras.Infra.Configurations;

namespace TrincaChurras.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSwaggerConfiguration()
                .AddCorsConfiguration()
                .AddAuthenticationConfiguration()
                .AddCoreConfiguration()
                .AddInfraConfiguration(Configuration)
                .AddDefaultConfiguration();            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseSwaggerConfiguration()
                .UseCorsConfiguration()
                .UseRouteConfiguration()
                .UseAuthenticationConfiguration()
                .UseDefaultConfiguration(env);
        }
    }
}
