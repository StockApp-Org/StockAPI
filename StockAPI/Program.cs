using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StockAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static string GetRootPath()
        {
            var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

            Regex appPathMatcher = new Regex(@"(?>!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin=)");
            var appRoot = appPathMatcher.Match(exePath).Value;

            return appRoot;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseContentRoot(GetRootPath())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://192.168.0.203:5050");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
