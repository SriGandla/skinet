using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
          var host =   CreateHostBuilder(args).Build();
          using(var scope = host.Services.CreateScope())
          {
              var services = scope.ServiceProvider;
              var loggerFactory = services.GetRequiredService<ILoggerFactory>();
              try
              {
                 var context = services.GetRequiredService<StoreContext>();
                 await context.Database.MigrateAsync();
                 await StoreContextSeed.SeedAsync(context,loggerFactory);
              }
              catch(Exception ex)
              {
                  var logger = loggerFactory.CreateLogger<Program>();
                  logger.LogError(ex,"An error occured during migration");
              }

          }

          host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
