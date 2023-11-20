using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Repositories;
using System.Runtime.CompilerServices;
using AlexaIOTInfraredRemoteAPI.Application.Services;
using AlexaIOTInfraredRemoteAPI.Domain.Services;

namespace AlexaIOTInfraredRemoteAPI.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IInfraredSignalService, InfraredSignalService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
