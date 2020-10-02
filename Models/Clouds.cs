using System;
using System.Collections.Generic;
using System.Text;

namespace WSvcHAOMWeatherConsumer.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Clouds
    {
        /// <summary>Cloudiness, %</summary>
        [Newtonsoft.Json.JsonProperty("all", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int All { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }
}
