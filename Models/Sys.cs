using System;
using System.Collections.Generic;
using System.Text;

namespace WSvcHAOMWeatherConsumer.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Sys
    {
        /// <summary>Internal parameter</summary>
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Type { get; set; }

        /// <summary>Internal parameter</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        /// <summary>Internal parameter</summary>
        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Message { get; set; }

        /// <summary>Country code (GB, JP etc.)</summary>
        [Newtonsoft.Json.JsonProperty("country", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Country { get; set; }

        /// <summary>Sunrise time, unix, UTC</summary>
        [Newtonsoft.Json.JsonProperty("sunrise", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Sunrise { get; set; }

        /// <summary>Sunset time, unix, UTC</summary>
        [Newtonsoft.Json.JsonProperty("sunset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Sunset { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

}
