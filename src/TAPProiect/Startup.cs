using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using TAP.StorageAccess;
using TAP.DataAccess;
using TAP.DataAccess.Repositories;
using TAP.DataAccess.SqlServer;
using TAP.DataAccess.SqlServer.Repositories;
using TAP.Services.Identity;
using TAP.Core.Entities;
using Microsoft.AspNetCore.Identity;


namespace TAP.Web
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
            services.AddControllersWithViews();
           /* services.AddTransient<TAPContext>(_ =>
            {
                var config = _.GetService<IConfiguration>();
                var connString = config.GetConnectionString("TAPDb");
                return new TAPContext(connString);
            });*/
            services.AddScoped(_ =>
            {
                var config = _.GetService<IConfiguration>();
                var connString = config.GetConnectionString("TAPDb");
                return new TAPContext(connString);
            });
            //services.AddMvc()
            //    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

            services.AddIdentity<User, Role>()
                .AddSignInManager()
                .AddDefaultTokenProviders();
            services.AddAuthentication()
                .AddCookie(opt =>
                {
                    opt.LoginPath = "Account/Login";
                    opt.LogoutPath = "Account/Logout";
                    opt.AccessDeniedPath = "Account/Denied";
                });
            //services.AddTransient<ICustomerServices, CustomerServices>();
            services.AddTransient<IDataRepository, DataRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserStore<User>, UserStore>();
            services.AddTransient<IUserPasswordStore<User>, UserStore>();
            services.AddTransient<ICustomUserPasswordStore, UserStore>();
            services.AddTransient<IRoleStore<Role>, RoleStore>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                /*endpoints.MapControllerRoute(
                    name: null,
                    pattern: "tap/hello",
                   // new { controller = "Home", action = "SayHello", name = "qwe"}
                    new { controller = "Home", action = "SayHello"}
                    );*/
                endpoints.MapControllerRoute(null, "Account/Login", new { area = "Account", controller = "Authentication", action = "Login" });
                endpoints.MapControllerRoute(null, "Register", new { area = "Account", controller = "Authentication", action = "Register" });
                endpoints.MapControllerRoute(null, "Account/EditUser", new { area = "Account", controller = "Authentication", action = "EditUser" });

                endpoints.MapControllerRoute(name: null,
                    pattern: "exemplu/Customers/Create",
                    new { area = "exemplu", controller = "Customers", action = "Create" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
