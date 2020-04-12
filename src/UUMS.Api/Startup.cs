using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Captain.DB2NET.NPoco;
using Captain.DB2NET.NPoco4SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NPoco;
using UUMS.Services;
using UUMS.Services.IServices;

namespace UUMS.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            HostingEnvironment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDb>(o =>
            {
                return new SqlServerDb(Configuration.GetConnectionString("UUMS"));
            });
            services.AddTransient<IAppService, AppService>();

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "用户统一管理系统",
                    Description = "用户统一管理系统API",
                });

                options.OrderActionsBy(o => o.RelativePath);
                options.IncludeXmlComments(Path.Combine(HostingEnvironment.ContentRootPath, "UUMS.API.xml"), true);
                options.IncludeXmlComments(Path.Combine(HostingEnvironment.ContentRootPath, "UUMS.Enitites.xml"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "用户统一管理系统API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
