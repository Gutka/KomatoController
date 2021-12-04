using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KomatoController.Models
{
    public class Temperature
    {
        public float temp { get; set; }
        public DateTime date { get; set; }
        public string color { get; set; }

        public Temperature(float temp, string date)
        {
            this.temp = temp;
            this.date = DateTime.Parse(date, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal); ;
            this.color = "green";//SKColor.Parse("#77d065")
        }
    }
}