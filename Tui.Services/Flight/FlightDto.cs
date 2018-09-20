using System;
using System.Collections.Generic;
using System.Text;

namespace Tui.Services.Flight
{
    public class FlightDto
    {
        public int DepartureAirportId { get; set; }
        public int DestinationAirportId { get; set; }
        public int AircraftId { get; set; }
        public double Distance { get; set; }
        public double FuelConsumption { get; set; }
    }
}
