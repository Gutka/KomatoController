using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KomatoController.Models
{
    class Humidity
    {
        public float humidity { get; set; }
        public DateTime date { get; set; }
        public string color { get; set; }

        public Humidity(float humidity, string date)
        {
            this.humidity = humidity;
            this.date = DateTime.Parse(date, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal); ;
            this.color = "blue"; //SKColor.Parse("00BFFF")
        }
    }
}
