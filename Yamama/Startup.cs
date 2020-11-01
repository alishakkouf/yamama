﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Yamama.Models;
using Yamama.Repository;
using Yamama.Services;
using Yamama.ViewModels;
using IEmailSender = Yamama.Repository.IEmailSender;
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
            //email
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddScoped<IEmailSender, EmailSender>();
            // Add application services.

            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<Iquestionnaire, QuestionnaireService>();
            services.AddScoped<IInvoicecs, InvoiceService>();
            services.AddScoped<ICart, CartService>();
            services.Configure<AuthMessageSMSSenderOptions>(Configuration);


            services.AddDbContextPool<yamamadbContext>(item => item.UseMySql
              (Configuration.GetConnectionString("yamamaConnection")));

            services.AddIdentity<ExtendedUser, IdentityRole>(Options =>
            {
                Options.Password.RequiredLength = 10;
                //Options.SignIn.RequireConfirmedEmail= true;

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
