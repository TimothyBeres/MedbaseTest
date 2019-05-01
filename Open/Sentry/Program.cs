using System;
using System.Linq;
using System.Linq.Dynamic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Open.Domain.Location;
using Open.Domain.Money;
using Open.Infra;
using Open.Infra.Location;
using Open.Infra.Money;
using Sentry1.Services;
using Open.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sentry1.Models;

namespace Open.Sentry1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                createRolesAddUserRoles(services);

                 try
                    {
                        var dbContext = services.GetRequiredService<SentryDbContext>();

                        DbTablesInitializer.Initialize(dbContext);
                        //CsvImporter.ClearMedicinesAndEffects();
                        //CsvImporter.Import();
                        //CsvImporter.DownloadPdf();
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger?.LogError(ex, "An error occured while seeding the database");
                    }
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        private static async Task createRolesAddUserRoles(IServiceProvider services)
        {
            await createRoles(services);
            await addUserRoles(services);
        }
        private static async Task createRoles(IServiceProvider service)
        {
            
            var roleManager = service.GetService<RoleManager<IdentityRole>>();

            var roles = Enum.GetValues(typeof(UserRoles));

            IdentityResult roleResult;

            foreach (var roleObject in roles)
            {
                var role = RoleExtensions.GetRoleName(roleObject);
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task addUserRoles(IServiceProvider service)
        {
            var userManager = service.GetService<UserManager<ApplicationUser>>();

            var randomUser = await userManager.Users.FirstOrDefaultAsync();
            var roleName = RoleExtensions.GetRoleName(UserRoles.Doctor);
            await userManager.AddToRoleAsync(randomUser, roleName);
        }
    }
}
