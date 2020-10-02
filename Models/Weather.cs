using System;
using System.Collections.Generic;
using System.Text;

namespace WSvcHAOMWeatherConsumer.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Weather
    {
        /// <summary>Weather condition id</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        /// <summary>Group of weather parameters (Rain, Snow, Extreme etc.)</summary>
        [Newtonsoft.Json.JsonProperty("main", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Main { get; set; }

        /// <summary>Weather condition within the group</summary>
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>Weather icon id</summary>
        [Newtonsoft.Json.JsonProperty("icon", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Icon { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }
}
