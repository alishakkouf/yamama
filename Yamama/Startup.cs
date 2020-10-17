using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yamama.Models;
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
            // Add application services.
            
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.Configure<AuthMessageSMSSenderOptions>(Configuration);


            services.AddDbContextPool<yamamadbContext>(item => item.UseMySql
              (Configuration.GetConnectionString("yamamaConnection")));

            services.AddIdentity<ExtendedUser, IdentityRole>(Options =>
            {
                Options.Password.RequiredLength = 10;
               // Options.SignIn.RequireConfirmedPhoneNumber = true;

            }).AddEntityFrameworkStores<yamamadbContext>()
            .AddDefaultTokenProviders();
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
