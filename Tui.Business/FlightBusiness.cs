using System;
using System.Threading.Tasks;
using Tui.Services.Aircraft;
using Tui.Services.Airport;
using Tui.Services.Flight;

namespace Tui.Business
{
    public class FlightBusiness : IFlightBusiness
    {
        private readonly IFlightService _flightService;
        private readonly IAircraftService _aircraftService;
        private readonly IAirportService _airportService;

        public FlightBusiness(IFlightService flightService, 
                              IAircraftService aircraftService, 
                              IAirportService airportService)
        {
            _flightService = flightService;
            _aircraftService = aircraftService;
            _airportService = airportService;
        }

        public async Task<bool> AddSync(FlightDto flight)
        {
            if (flight == null)
                throw new ArgumentNullException(nameof(AddSync));
            try
            {
                flight = await CompleteFlight(flight);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            
           return await _flightService.AddAsync(flight);
            
        }
        public async Task<bool> UpdateAsync(UpdateFlightDto flight)
        {
            if (flight == null)
                throw new ArgumentNullException(nameof(UpdateAsync));
            try
            {
                flight = (UpdateFlightDto)await CompleteFlight(flight);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
                        
           return await _flightService.UpdateAsync(flight);
        }

        private async Task<FlightDto> CompleteFlight(FlightDto flight)
        {
            var destination = await _airportService.GetAsync(flight.DestinationAirportId);
            var departure = await _airportService.GetAsync(flight.DepartureAirportId);
            var aircraft = await _aircraftService.GetAsync(flight.AircraftId);

            if (destination == null || departure == null || aircraft == null)
                throw new ArgumentNullException(nameof(CompleteFlight));

            flight.Distance = DistanceBetweenPlaces(departure, destination);
            flight.FuelConsumption = FuelConsumption(aircraft, flight.Distance);

            return flight;
        }
       

        private  double Radians(double x)
        {
            return x * Math.PI / 180;
        }
        private double FuelConsumption(AircraftDto aircraft, double distance)
        {
            return aircraft.FuelConsumption * distance + aircraft.TakeOffEffort;
        }
         private double DistanceBetweenPlaces(AirportDto departure,AirportDto destination)
        {
            var R = 6371; // km

            var latDepartureSinus = Math.Sin(Radians(departure.Latitude));
            var latDestinationSinus = Math.Sin(Radians(destination.Latitude));
            var latDepartureCosinus = Math.Cos(Radians(departure.Latitude));
            var latDestiniationCosinus = Math.Cos(Radians(destination.Latitude));
            var longitudeCosinus = Math.Cos(Radians(departure.Longitude) - Radians(destination.Longitude));

            var cosD = latDepartureSinus * latDestinationSinus + latDepartureCosinus * latDestiniationCosinus * longitudeCosinus;

            var d = Math.Acos(cosD);

            var dist = R * d;

            return dist;
        }

        
    }
}
