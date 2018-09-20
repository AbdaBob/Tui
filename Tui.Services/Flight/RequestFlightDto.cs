using System;
using System.Collections.Generic;
using System.Text;

namespace Tui.Services.Flight
{
    public class RequestFlightDto
    {
        public int Id { get; set; }
        public int DepartureAirportId { get; set; }
        public int DestinationAirportId { get; set; }
        public int AircraftId { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public string Aircraft { get; set; }
        public double Distance { get; set; }
        public double FuelConsumption { get; set; }
    }
}
