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
         * �������� Main����
         * asp.net core application => console application
         * ��һ������asp.net������ؿ�Ŀ���̨Ӧ�ó���
         * Main������Ҫ�������ú����г���
         */
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /*
         * web������Ҫ������CreateHostBuilder����һ��IHostBuilder
         * ����Ҫ������ kestrel ��Ĭ�ϵķ�������ͨ��ʹ��UseKestrel����
         * ����ʱʹ�õ���IIS ��Ϊkestrel�ķ�����������
         * Linux ����ʹ��nginx
         */

        /// <summary>
        /// ����IHostBuilder
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
