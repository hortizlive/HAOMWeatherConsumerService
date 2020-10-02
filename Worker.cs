using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WSvcHAOMWeatherConsumer.APIClients.OpenWeatherMapAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using WSvcHAOMWeatherConsumer.DataAccessService;
using WSvcHAOMWeatherConsumer.Models;

namespace WSvcHAOMWeatherConsumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
      
        private readonly Client OWMClient;
        private readonly Units _units;
        private readonly string filePath;
        private string fileName;
        private readonly int _cityId;
        private readonly ICSVWeatherLogger _csvLogger;
        private readonly int _PollCycleSeconds;
        
        public Worker(ILogger<Worker> logger,IConfiguration config,ICSVWeatherLogger csvLogger)
        {
            _logger = logger;
           
            HttpClient httpClt = new HttpClient();
            OWMClient = new Client(httpClt);
            //GET the configuration Values
            OWMClient.BaseUrl= config.GetValue<string>("OpenWeatherMap:BaseURL");
            OWMClient.ApiKey = config.GetValue<string>("OpenWeatherMap:API_Key");
            _cityId = config.GetValue<int>("HAOMWeatherService:CityID");
            filePath = config.GetValue<string>("HAOMWeatherService:FilePath");
  
            var sUnits = config.GetValue<string>("HAOMWeatherService:Units");
            if (!Enum.TryParse<Units>(sUnits, out _units))
            {
                var msg = "Error starting service, there is an error in the configuration, invalid Units Value, service is stopping";
                _logger.LogCritical(msg);
                throw new Exception("msg");
            }
            _PollCycleSeconds = config.GetValue<int>("HAOMWeatherService:PollTimeSeconds");
            _csvLogger = csvLogger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                string tempUnits = "";
                //Here i must get the Weather for Dallas
                _logger.LogInformation("Here I must get the wheather for the City then write it down");
                try
                {

                    switch (_units)
                    {
                        case Units.Standard:
                            tempUnits = "K";   //kelvin
                            break;
                        case Units.Metric:
                            tempUnits = "C"; //Celsius
                            break;
                        case Units.Imperial:
                            tempUnits = "F"; //Farenheit   
                            break;
                        default:
                            tempUnits = "K";//default kelvin
                            break;
                    }
                    var WeatherResponse = await OWMClient.CurrentWeatherDataAsync(null, _cityId.ToString(), null, null,null,_units,null,null,stoppingToken);
                    if (stoppingToken.IsCancellationRequested)  return;
                    
                    _logger.LogInformation("Current Weather Conditions in City:{Name} @UTC:{Time} are: {WeatherResponse} ",WeatherResponse.Name,DateTimeOffset.UtcNow, JObject.FromObject(WeatherResponse).ToString());
                  

                  

                    WeatherRecord wRecord= new WeatherRecord
                    {
                        RecordDateUTC = DateTimeOffset.UtcNow,
                        Temperature = WeatherResponse.Main.Temp,
                        Units = tempUnits,
                        Precipitation = WeatherResponse.ExistPrecipitation()

                    };
                    fileName = WeatherResponse.Name + "_WeatherLog";
                    _logger.LogInformation("Writing weather record:{Record} ", JObject.FromObject(wRecord).ToString());
                    await _csvLogger.AddWeatherEntryAsync(wRecord, fileName, filePath);
                }
                catch (Exception EX)
                {
                    //Log warning then continue to execute
                    _logger.LogWarning("error obtaining the weather for cityID:" + EX.Message);
                    
                }
                
      
                //wait for the next time to execute
                await Task.Delay(_PollCycleSeconds * 1000, stoppingToken);
                if (stoppingToken.IsCancellationRequested)
                    return;
    
            }
        }
    }
}
