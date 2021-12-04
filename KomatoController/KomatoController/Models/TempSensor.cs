using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace KomatoController.Models
{
    public class TempSensor
    {
        [JsonProperty(PropertyName = "temp")]
        public float Temp
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "humidity")]
        public float Humidity
        {
            get;
            set;
        }
    }
}
