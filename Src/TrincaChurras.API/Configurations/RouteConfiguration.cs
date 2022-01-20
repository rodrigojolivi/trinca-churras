using Microsoft.AspNetCore.Builder;

namespace TrincaChurras.API.Configurations
{
    public static class RouteConfiguration
    {
        public static IApplicationBuilder UseRouteConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            return app;
        }
    }
}
