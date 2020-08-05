using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Blog.Core
{
    public class Program
    {
        /*
         * 程序的入口 Main方法
         * asp.net core application => console application
         * 是一个调用asp.net核心相关库的控制台应用程序
         * Main方法主要用于配置和运行程序
         */
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /*
         * web程序需要主机，CreateHostBuilder创建一个IHostBuilder
         * 还需要服务器 kestrel 是默认的服务器，通过使用UseKestrel启用
         * 开发时使用的是IIS 作为kestrel的反向代理服务器
         * Linux 可以使用nginx
         */

        /// <summary>
        /// 创建IHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
