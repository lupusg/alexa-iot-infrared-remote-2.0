using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Repositories;
using System.Runtime.CompilerServices;

namespace AlexaIOTInfraredRemoteAPI.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISignalRepository, SignalRepository>();
            return services;
        }
    }
}
