using Catharsium.BasicAuthentication.Api.Interfaces;
using Catharsium.BasicAuthentication.Api.Services;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.BasicAuthentication.Api.Configuration
{
    public static class BasicAuthenticationRegistration
    {
        public static IServiceCollection AddBasicAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<BasicAuthenticationConfiguration>();
            
            services.AddScoped<IUserService, InMemoryUserService>();

            return services;
        }
    }
}