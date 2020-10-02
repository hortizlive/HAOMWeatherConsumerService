using System;
using System.Collections.Generic;
using System.Text;

namespace WSvcHAOMWeatherConsumer.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class CurrentWeatherResult
    {
        [Newtonsoft.Json.JsonProperty("coord", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Coord Coord { get; set; }

        /// <summary>(more info Weather condition codes)</summary>
        [Newtonsoft.Json.JsonProperty("weather", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Weather> Weather { get; set; }

        /// <summary>Internal parameter</summary>
        [Newtonsoft.Json.JsonProperty("base", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Base { get; set; }

        [Newtonsoft.Json.JsonProperty("main", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Main Main { get; set; }

        /// <summary>Visibility, meter</summary>
        [Newtonsoft.Json.JsonProperty("visibility", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Visibility { get; set; }

        [Newtonsoft.Json.JsonProperty("wind", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Wind Wind { get; set; }

        [Newtonsoft.Json.JsonProperty("clouds", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Clouds Clouds { get; set; }

        [Newtonsoft.Json.JsonProperty("rain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Rain Rain { get; set; }

        [Newtonsoft.Json.JsonProperty("snow", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Snow Snow { get; set; }

        /// <summary>Time of data calculation, unix, UTC</summary>
        [Newtonsoft.Json.JsonProperty("dt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Dt { get; set; }

        [Newtonsoft.Json.JsonProperty("sys", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Sys Sys { get; set; }

        /// <summary>City ID</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>Internal parameter</summary>
        [Newtonsoft.Json.JsonProperty("cod", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Cod { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        /// <summary>
        /// Funtion to get if there is precipitation based on the weather conditions ID's of the current object wheater conditions collection
        /// </summary>
        /// <returns>true if exist a weather condition that implies precipitation otherwise it returns false</returns>
        public Boolean ExistPrecipitation()
        {
            // check the Weahter Condition codes in https://openweathermap.org/weather-conditions
            // following conditions are considered to have precipitation = true
            //2XX thunderstorm 
            //3XX Drizzle
            //5XX rain
            //6XX Snow
            //Following Conditions does not implies precipitation
            //7XX Atmospheric conditions(FOG, ASH, SMOKE,)
            //800 Clear
            //80X Clouds
            // then if the ID of any of the Items in the Wheather Collection is below 600 then we have Precipitation = true
            foreach (var thisWeatherCondition in this.Weather)
            {
                if (thisWeatherCondition.Id < 700)
                    return true;
            }
            return false;//if we get through all the contitions with out finding precipitation code then there is no precipitation


        }

    }
}
