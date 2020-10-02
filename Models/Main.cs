using System;
using System.Collections.Generic;
using System.Text;

namespace WSvcHAOMWeatherConsumer.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Main
    {
        /// <summary>Temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.</summary>
        [Newtonsoft.Json.JsonProperty("temp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Temp { get; set; }

        /// <summary>Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa</summary>
        [Newtonsoft.Json.JsonProperty("pressure", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Pressure { get; set; }

        /// <summary>Humidity, %</summary>
        [Newtonsoft.Json.JsonProperty("humidity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Humidity { get; set; }

        /// <summary>Minimum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.</summary>
        [Newtonsoft.Json.JsonProperty("temp_min", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Temp_min { get; set; }

        /// <summary>Maximum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.</summary>
        [Newtonsoft.Json.JsonProperty("temp_max", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Temp_max { get; set; }

        /// <summary>Atmospheric pressure on the sea level, hPa</summary>
        [Newtonsoft.Json.JsonProperty("sea_level", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Sea_level { get; set; }

        /// <summary>Atmospheric pressure on the ground level, hPa</summary>
        [Newtonsoft.Json.JsonProperty("grnd_level", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Grnd_level { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }
}
