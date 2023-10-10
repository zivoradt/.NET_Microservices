using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Data;
using PlatformService.Services;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Services
{
    public static class Services

    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(opt => opt.UseInMemoryDatabase("InMem"));

            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpClient<ICommandDataClient, HttoCommandDataClient>();

            services.AddScoped<IPlatformRepo, PlatformRepo>();

            return services;
        }
    }
}