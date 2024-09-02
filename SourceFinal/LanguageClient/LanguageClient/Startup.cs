using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        bool sessionChecked = false;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddSession();
            services.AddOcelot();

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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();

            app.UseSession();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/" ||
                    context.Request.Path == "/Index")
                {
                    if (context.Session.GetString("AccessToken") == null)
                    {
                        context.Response.Redirect("/Login/Login");
                        return;
                    }
                }
                else if (context.Request.Path.StartsWithSegments("/Admin") == true)
                {
                    if (context.Session.GetString("AccessToken") == null)
                    {
                        context.Response.Redirect("/Login/Login");
                        return;
                    }
                }
                else if (context.Request.Path.StartsWithSegments("/LanguageCharts") == true)
                {
                    if (context.Session.GetString("AccessToken") == null)
                    {
                        context.Response.Redirect("/Login/Login");
                        return;
                    }
                }
                await next();
            });



            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.UseOcelot().Wait();
        }

    }
}
