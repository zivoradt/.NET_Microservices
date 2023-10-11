using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    // Prepare DB for migrations
    public static class PrepDB
    {
        private static void SeedData(AppDBContext dbContext, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attemptiing to apply migrations...");
                try
                {
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run migration: {ex.Message}");
                }
            }

            if (!dbContext.Platform.Any())
            {
                Console.WriteLine("--> Seeding data!");

                dbContext.Platform.AddRange(
                    new Platform() { Name = "Don Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Platform", Cost = "Free" },
                    new Platform() { Name = "Docker", Publisher = "Cloud Platform", Cost = "Free" }
                    );

                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data!");
            }
        }

        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDBContext>(), isProd);
            }
        }
    }
}