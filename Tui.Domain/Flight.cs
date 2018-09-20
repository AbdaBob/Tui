namespace Tui.Domain
{
    public class Flight
    {
        public int Id { get; set; }
        public int? DepartureAirportId { get; set; }
        public int? DestinationAirportId { get; set; }
        public int? AircraftId { get; set; }
        public double Distance { get; set; }
        public double FuelConsumption { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport DestinationAirport { get; set; }
        public Aircraft Aircraft { get; set; }
    }
}
