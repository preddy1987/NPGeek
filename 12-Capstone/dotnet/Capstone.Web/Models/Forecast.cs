using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Forecast
    {
        public string ParkCode { get; set; }
        public int DayOfTheWeek { get; set; }
        public int LowTemp { get; set; }
        public int HighTemp { get; set; }
        public string DailyForecast { get; set; }
    }
}
