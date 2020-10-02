using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSvcHAOMWeatherConsumer.Models;
using CsvHelper;

namespace WSvcHAOMWeatherConsumer.DataAccessService
{
    public interface ICSVWeatherLogger
    {
        public Task<bool> AddWeatherEntryAsync(WeatherRecord currentInfo, string fileName, string filePath);

    }
}
