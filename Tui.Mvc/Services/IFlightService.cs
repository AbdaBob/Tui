using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tui.Mvc.Models;

namespace Tui.Mvc.Services
{
    public interface IFlightService
    {
        /// <summary>
        /// Get all fligths
        /// </summary>
        /// <returns></returns>
        Task<List<FlightResultDetailModel>> GetFlights();

        /// <summary>
        /// Get flight by id
        /// </summary>
        /// <returns></returns>
        Task<FlightDetailModel> GetFlight(int id);
        /// <summary>
        /// Adding a flight
        /// </summary>
        /// <param name="model"></param>
        Task AddFlight(PostFlightModel model);
        /// <summary>
        /// Update a flight
        /// </summary>
        /// <param name="model"></param>
        Task UpdateFlight(PostFlightModel model);

        /// <summary>
        /// Get airports list
        /// </summary>
        /// <returns></returns>
        Task<List<AirportModel>> GetAirports();
        /// <summary>
        /// Get aircraft list
        /// </summary>
        /// <returns></returns>
        Task<List<AircraftModel>> GetAircrafts();
    }
}
