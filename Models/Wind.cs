using System;
using System.Collections.Generic;
using System.Text;

namespace WSvcHAOMWeatherConsumer.Models
{

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Wind
    {
        /// <summary>Wind speed. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.</summary>
        [Newtonsoft.Json.JsonProperty("speed", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Speed { get; set; }

        /// <summary>Wind direction, degrees (meteorological)</summary>
        [Newtonsoft.Json.JsonProperty("deg", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Deg { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }
}
