using System;
using System.Collections.Generic;
using System.Text;

namespace WSvcHAOMWeatherConsumer.Models
{
    public class WeatherRecord
    {
        public DateTimeOffset RecordDateUTC { get; set; }
        public double Temperature { get; set; }

        public string Units { get; set; }

        public Boolean Precipitation { get; set; }


    }
}
