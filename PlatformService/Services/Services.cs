using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.AsyncDataService;
using PlatformService.Data;
using PlatformService.Services;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Services
{
    public static class Services
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IWebHostEnvironment env, IConfiguration config)
        {
            if (env.IsProduction())
            {
                Console.WriteLine("--> Using SQLServer DB");

                services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(config.GetConnectionString("PlatformsConn")));
            }
            else
            {
                Console.WriteLine("--> Using InMemory DB");
                services.AddDbContext<AppDBContext>(opt => opt.UseInMemoryDatabase("InMem"));
            }

            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpClient<ICommandDataClient, HttoCommandDataClient>();

            services.AddSingleton<IMessageBusClient, MessageBusClient>();

            services.AddScoped<IPlatformRepo, PlatformRepo>();

            return services;
        }
    }
}