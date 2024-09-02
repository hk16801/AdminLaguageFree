using DataAccess;
using DataAccess.DAO;
using BusinessObject.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Reponsitory;
using Reponsitory.IService;
using Reponsitory.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Identity;
using BusinessObject.Model;
using Repository.Service;
using Repository.IService;

namespace Language_API
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
            services.AddOptions();
            var mailsetting = Configuration.GetSection("MailSettings");
            services.Configure<EmailSetting>(mailsetting);
            services.AddTransient<EmailRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<AccessLogsIRepository, AccessLogsRepository>();
            services.AddTransient<AccessLogsDAO>();
            services.AddTransient<AccountsIRepository, AccountsRepository>();
            services.AddTransient<AccountsDAO>();
            services.AddTransient<CommentsIRepository, CommentsRepository>();
            services.AddTransient<CommentsDAO>();
            services.AddTransient<LanguageLogsIRepository, LanguageLogsRepository>();
            services.AddTransient<LanguageLogsDAO>();
            services.AddTransient<PagesIRepository, PagesRepository>();
            services.AddTransient<PagesDAO>();
            services.AddTransient<RatesIRepository, RatesRepository>();
            services.AddTransient<RatesDAO>();
            services.AddTransient<RolesIRepository, RolesRepository>();
            services.AddTransient<RolesDAO>();
            services.AddTransient<SettingsIRepository, SettingsRepository>();
            services.AddTransient<SettingsDAO>();
            services.AddTransient<TranslationHistorysIRepository, TranslationHistorysRepository>();
            services.AddTransient<TranslationHistorysDAO>();
            services.AddTransient<UsersIRepository, UsersRepository>();
            services.AddTransient<UsersDAO>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Language_API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
            services.AddAuthorization(option =>
            {
                option.AddPolicy(IdentifyRole.AdminRole, p => p.RequireClaim(IdentifyRole.RoleRequired, "True"));
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "issuer",
                    ValidAudience = "audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet."
                ))
                };
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Language_API v1"));
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}