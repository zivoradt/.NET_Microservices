using CommandService.Data;
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
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMem"));
            services.AddScoped<ICommandRepo, CommandRepo>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}