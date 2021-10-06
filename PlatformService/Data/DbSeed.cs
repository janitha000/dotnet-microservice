using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Data
{
    public static class DbSeed
    {
        public static void Populate(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var isDevelopment = env.IsDevelopment();

            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isDevelopment);
            }
        }

        private static void SeedData(AppDbContext context, bool isDevelopment)
        {
            if(isDevelopment)
            {
                Console.WriteLine("Running migrations on the database .......");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (!context.Platforms.Any())
            {
                Console.WriteLine("Seeding to the database .....");

                var platforms = new Platform[]
                {
                    new Platform { Id = 1, Name="Dot Net", Publisher="Microsoft", Cost=200},
                    new Platform { Id = 2, Name="Dot Net Core", Publisher="Microsoft", Cost=0},
                    new Platform { Id = 3, Name="Nodejs", Publisher="Google", Cost=0},
                };

                context.Platforms.AddRange(platforms);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("DB already have data");
            }
        }
    }
}
