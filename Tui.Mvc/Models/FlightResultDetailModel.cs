using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tui.Mvc.Models
{
    public class FlightResultDetailModel
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public string Aircraft { get; set; }
        public double Distance { get; set; }
        public double FuelConsumption { get; set; }
    }
}
