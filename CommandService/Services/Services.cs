using CommandService.AsyncDataService;
using CommandService.Data;
using CommandService.EventProcessing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Services;

namespace PlatformService.Services
{
    public static class Services

    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddHostedService<MessageBusSubscriber>();
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMem"));
            services.AddSingleton<IEventProcessor, EventProcessor>();
            services.AddScoped<ICommandRepo, CommandRepo>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}