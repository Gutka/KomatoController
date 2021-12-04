using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace KomatoController.Models
{
    public class EnvRecord
    {
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "runID")]
        public int RunID
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "date")]
        public DateTime Date
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "lightSensor")]
        public bool Light
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "tempSensor")]
        public List<TempSensor> TempSensor
        {
            get;
            set;
        }

    }
}
