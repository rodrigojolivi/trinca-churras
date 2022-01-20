using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrincaChurras.Core.Interfaces.Repositories;
using TrincaChurras.Infra.Contexts;
using TrincaChurras.Infra.Repositories;
using TrincaChurras.Infra.Security;

namespace TrincaChurras.Infra.Configurations
{
    public static class InfraConfiguration
    {
        public static IServiceCollection AddInfraConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            #region Repositories

            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Context

            services.AddDbContext<TrincaChurrasContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            #endregion

            #region Security Token

            services.AddScoped<ITokenService, TokenService>();

            var key = Encoding.ASCII.GetBytes(configuration["ApiSecret"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #endregion

            return services;
        }
    }
}
