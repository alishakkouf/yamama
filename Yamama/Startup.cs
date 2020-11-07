using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Internal;
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

using Yamama.Models;
using Yamama.Repository;
using Yamama.Services;
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

            }).AddEntityFrameworkStores<yamamadbContext>();


            // inject the repositories and services classes
            services.AddScoped<IFactory, FactoryService>();
            services.AddScoped<IProject, ProjectService>();
            services.AddScoped<IPhoto, PhotoService>();
            services.AddScoped<IProduction, ProductionService>();
            services.AddScoped<I_ImportInvoce, ImportInvoiceService>();
            //services.AddScoped<IInvoice, InvoiceService>();
            services.AddScoped<ICart, CartService>();
            services.AddScoped<IStore, StoreService>();
            services.AddScoped<IBalance, BalanceService>();

            services.AddScoped<IProduct, ProductService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSignalR();
            //services.AddScoped<IVisit, VisitServices>();
            services.AddScoped<ITask, TaskService>();
            services.AddScoped<IAlert, AlertServices>();
            services.AddScoped<IRequestInformation, RequestInformationServices>();
            services.AddScoped<IProductionByType, ProductionByTypeServices>();
            services.AddScoped<INeeds, NeedsServices>();
            services.AddScoped<IIntencive, IntencivesServices>();
            services.AddScoped<ITarget, TargetServices>();
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
