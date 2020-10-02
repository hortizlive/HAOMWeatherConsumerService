using CsvHelper;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using WSvcHAOMWeatherConsumer.Models;

namespace WSvcHAOMWeatherConsumer.DataAccessService
{
    public class CurrentResultWriterService : ICSVWeatherLogger
    {
        private readonly ILogger<CurrentResultWriterService> _logger;

        public CurrentResultWriterService(ILogger<CurrentResultWriterService> Logger)
        {
            _logger = Logger;
        }
        public async Task<bool> AddWeatherEntryAsync(WeatherRecord currentInfo, string fileName, string filePath)
        {
            TextWriter sWriter;
            string fullFilePath =Path.Combine(filePath, Path.GetFileNameWithoutExtension(fileName) + ".csv");

            var newFile=!File.Exists(fullFilePath);

            try
            {
                using (sWriter = new StreamWriter(fullFilePath, true, new UTF8Encoding(true)))
                using (var CsvWriter = new CsvWriter(sWriter, System.Globalization.CultureInfo.InvariantCulture, false))
                {

                    if (newFile)
                    {
                        CsvWriter.WriteHeader<WeatherRecord>();
                        await CsvWriter.NextRecordAsync();
                    }
                    CsvWriter.WriteRecord(currentInfo);
                    await CsvWriter.NextRecordAsync();

                }
                return true;
            }
            catch (DirectoryNotFoundException Ex)
            {
                string Msg = $"Error writing the Weather Log to CSV file: {fileName}.CSV, the directory:{filePath} was not found!";
                _logger.LogError(Ex, Msg);
                throw Ex;

            }
            catch (AccessViolationException Ex) {
                var User=WindowsIdentity.GetCurrent();
                string Msg = $"Error writing the Weather Log to CSV file: {fileName}.CSV, in Directory:{filePath}, the user running the service:{User.Name} does not have write access to the file or folder";
                _logger.LogError(Ex, Msg);
                throw Ex;
            }
            catch (Exception Ex)
            {

                string Msg = $"Error writing the Weather Log to CSV file: {fileName}.CSV, in Directory:{filePath}, Message:{Ex.Message} " + (Ex.InnerException != null ? " Inner Exception: " + Ex.InnerException.Message : "");
                _logger.LogError(Ex, Msg);
                throw Ex;

                throw;
            }
           
          
        }
    }
}
