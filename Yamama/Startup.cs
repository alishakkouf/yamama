using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yamama.Repository;
using Yamama.Services;
//using Yamama.Models.AppYamamaContext;

namespace Yamama
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
            services.AddDbContextPool<yamamadbContext>(item => item.UseMySql
              (Configuration.GetConnectionString("yamamaConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(Options =>
            {
                Options.Password.RequiredLength = 10;

            }).AddEntityFrameworkStores<yamamadbContext>();


            // inject the repositories and services classes
            services.AddScoped<IFactory, FactoryService>();
            services.AddScoped<IProject, ProjectService>();
            services.AddScoped<IPhoto, PhotoService>();
            services.AddScoped<IProduction, ProductionService>();
            services.AddScoped<I_ImportInvoce, ImportInvoiceService>();
            services.AddScoped<I_Invoice, InvoiceService>();
            services.AddScoped<ICart, CartService>();
            services.AddScoped<IStore, StoreService>();
            services.AddScoped<IBalance, BalanceService>();

            services.AddScoped<IProduct, ProductService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
