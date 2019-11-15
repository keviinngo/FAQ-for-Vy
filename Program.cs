using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividuellAngular.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IndividuellAngular
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()) 
            { 
                var services = scope.ServiceProvider; 
                try { 
                    var context = services.GetRequiredService<QuestionContext>(); 
                    context.Database.EnsureCreated(); } catch (Exception ex) 
                { 
                    var logger = services.GetRequiredService<ILogger<Program>>(); 
                    logger.LogError(ex, "An error occurred creating the DB."); 
                } 
            }
            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
