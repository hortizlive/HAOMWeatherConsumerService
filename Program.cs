using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.Extensions.Hosting.WindowsServices;
using WSvcHAOMWeatherConsumer.DataAccessService;

namespace WSvcHAOMWeatherConsumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddTransient<ICSVWeatherLogger,CurrentResultWriterService>();

                services.AddHostedService<Worker>()                
            .Configure<EventLogSettings>(config =>
                {
                    config.LogName = "HAOM WeatherConsumer Service";
                    config.SourceName = "HAOM WeatherConsumer  Service Source";
                });
            }).UseWindowsService();
    }
}
