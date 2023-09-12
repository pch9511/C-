using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using Franchise.Web.Settings;
using Microsoft.AspNetCore.Http;
using Franchise.Web.Models;

namespace Franchise.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSession();
            // Add framework services.
            services.AddMvc();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMailRepository, MailRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<INoteCommentRepository, NoteCommentRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IQnARepository, QnARepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseCookieAuthentication(
                new CookieAuthenticationOptions()
                {
                    AuthenticationScheme = "Cookies",
                    LoginPath = new PathString("/User/Login"),
                    AccessDeniedPath = new PathString("/User/Forbidden"),
                    AutomaticAuthenticate = true,
                    AutomaticChallenge = true
                }
            );

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=User}/{action=Login}/{id?}");
            });
        }
    }
}
