using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Blog.Core
{
    public class Startup
    {
        /*
         * Startup项目的启动文件
         * 所有启动相关都在这里配置
         * 包括依赖注入、跨域请求、Redis缓存等
         */

        /// <summary>
        /// 接口名
        /// </summary>
        public string ApiName { get; set; } = "Blog.Core";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // 如果是MVC项目可以使用AddControllersWithViews
            services.AddControllers();

            #region 注册Swagger服务

            // 注册Swagger服务
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",

                    Title = $"{ApiName}接口文档-NETCore 3.1",

                    Description = $"{ApiName}  HTTP API V1",

                    Contact = new OpenApiContact
                    {
                        Name = ApiName,
                        Email = "JontyMin@qq.com",
                        Url = new Uri("https://www.jonty.top")
                    },

                    License = new OpenApiLicense
                    {
                        Name = ApiName,
                        Url = new Uri("https://www.jonty.top")
                    }
                });

                /*
                 * 如果想要去除⚠，可以在项目生成=>取消项目警告+1591
                 */
                
                // xml文档地址
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Blog.Core.xml");

                // 第二个参数为控制器注释，默认false
                options.IncludeXmlComments(xmlPath,true);

                var xmlModelPath = Path.Combine(AppContext.BaseDirectory, "Blog.Core.Model.xml");
                options.IncludeXmlComments(xmlModelPath);

                options.OrderActionsBy(x => x.RelativePath);
            });

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 启动swagger中间件
            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint($"/swagger/v1/swagger.json", $"{ApiName} V1");
                
                // 默认根域名打开
                x.RoutePrefix = "";

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
