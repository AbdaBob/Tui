using System;
using System.Collections.Generic;
using System.Text;

namespace Tui.Services.Aircraft
{
    public class AircraftDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double FuelConsumption { get; set; }
        public double TakeOffEffort { get; set; }

    }
}
