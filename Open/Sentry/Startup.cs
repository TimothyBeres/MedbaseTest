using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Open.Domain.Location;
using Open.Domain.Money;
using Open.Domain.Product;
using Open.Infra;
using Open.Infra.Location;
using Open.Infra.Money;
using Open.Infra.Product;
using Sentry1.Data;
using Sentry1.Models;
using Sentry1.Services;

namespace Open.Sentry1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            setDatabase(services);
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            setAuthentication(services);
            services.AddTransient<IEmailSender, EmailSender>();
            setMvcWithAntyFoggeryToken(services);
            services.AddScoped<ICountryObjectsRepository, CountryObjectsRepository>();
            services.AddScoped<ICurrencyObjectsRepository, CurrencyObjectsRepository>();
            services.AddScoped<ICountryCurrencyObjectsRepository, CountryCurrencyObjectsRepository>();
            services.AddScoped<IAddressObjectsRepository, AddressObjectsRepository>();
            services.AddScoped<ITelecomDeviceRegistrationObjectsRepository, TelecomDeviceRegistrationObjectsRepository>();
            services.AddScoped<IEffectObjectsRepository, EffectObjectsRepository>();
            services.AddScoped<IMedicineObjectsRepository, MedicineObjectsRepository>();
            services.AddScoped<IMedicineEffectsObjectsRepository, MedicineEffectsObjectsRepository>();
            
        }

        protected virtual void setMvcWithAntyFoggeryToken(IServiceCollection services)
        {
            services.AddMvc();
        }

        protected virtual void setAuthentication(IServiceCollection services)
        {

        }

        protected virtual void setDatabase(IServiceCollection services)
        {
            var s = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(s));
            services.AddDbContext<SentryDbContext>(
                options => options.UseSqlServer(s));
            services.AddDbContext<SentryDbContext>(
                options => options.UseSqlServer(s));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            setErrorPage(app, env);
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        protected virtual void setErrorPage(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
        }
    }
}
