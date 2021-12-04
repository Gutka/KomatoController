using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KomatoController.Models
{
    class Light
    {
        public bool state { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string color { get; set; }

        public Light(bool state, string date)
        {
            this.state = state;
            this.date = DateTime.Parse(date, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal); ;
            this.color = "red"; //SKColor.Parse("#FF1943")
        }
    }
}
