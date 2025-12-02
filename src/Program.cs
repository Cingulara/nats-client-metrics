using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using NLog;

namespace nats_client_metrics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration("nlog.config");
            var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("LOGLEVEL"))) // default
                NLog.LogManager.Configuration.Variables["logLevel"] = "Warn";
            else {
                switch (Environment.GetEnvironmentVariable("LOGLEVEL"))
                {
                    case "5":
                        NLog.LogManager.Configuration.Variables["logLevel"] = "Critical";
                        break;
                    case "4":
                        NLog.LogManager.Configuration.Variables["logLevel"] = "Error";
                        break;
                    case "3":
                        NLog.LogManager.Configuration.Variables["logLevel"] = "Warn";
                        break;
                    case "2":
                        NLog.LogManager.Configuration.Variables["logLevel"] = "Info";
                        break;
                    case "1":
                        NLog.LogManager.Configuration.Variables["logLevel"] = "Debug";
                        break;
                    case "0":
                        NLog.LogManager.Configuration.Variables["logLevel"] = "Trace";
                        break;
                    default:
                        NLog.LogManager.Configuration.Variables["logLevel"] = "Warn";
                        break;
                }
            }
            NLog.LogManager.ReconfigExistingLoggers();
            try
            {
                logger.Debug("init main");
                CreateHostBuilder(args).Build().Run(); 
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception with logging. Please investigate.");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {                    
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        // Set properties and call methods on options
                        // make the timeout 10 minutes for longer running processes
                        serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
                    })                        
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                    })
                    .UseNLog()  // NLog: setup NLog for Dependency injection
                    .UseStartup<Startup>();
                });
    }
}
