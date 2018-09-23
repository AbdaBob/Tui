using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tui.Infrastructure;
using Tui.Domain;
using Tui.Infrastructure.Flight;
using AutoMapper;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Tui.Services.Flight
{
    /// <summary>
    /// flight service
    /// Handling all about flights
    /// </summary>
    
    public class FlightService : IFlightService
    {
        private IFlightRepository _flightRepository;
        private IMapper _mapper;
        private ILogger<IFlightService> _logger;

        public FlightService(IFlightRepository repository, IMapper mapper,ILogger<IFlightService> logger)
        {
            _flightRepository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// Adding flight
        /// </summary>
        /// <param name="flight">flight dto</param>
        /// <returns>bool</returns>

        public async Task<bool> AddAsync(FlightDto flight)
        {
            var dalFlight = _mapper.Map<Domain.Flight>(flight);
            try
            {
                await _flightRepository.CreateAsync(dalFlight);
                return dalFlight.Id > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddSync { ex.Message}");
                return false;
            }
        }
        /// <summary>
        /// Get one flight
        /// </summary>
        /// <param name="id">flight id</param>
        /// <returns>request flight dto</returns>

        public async Task<RequestFlightDto> GetAsync(int id)
        {
            var flight = await _flightRepository.GetAsync(f => f.Id == id);
            return flight != null ? _mapper.Map<RequestFlightDto>(flight) : null;
        }

        /// <summary>
        /// Get all fligths
        /// </summary>
        /// <returns>flights</returns>
        public async Task<List<RequestFlightDto>> GetAllAsync()
        {
            var fligths = await _flightRepository.GetAllAsync(null, "DestinationAirport", "DepartureAirport","Aircraft");
            return fligths.Select(c => _mapper.Map<RequestFlightDto>(c)).ToList();
        }

        /// <summary>
        /// update one flight
        /// </summary>
        /// <param name="flight">fligth dto</param>
        /// <returns>bool result</returns>
        public async Task<bool> UpdateAsync(UpdateFlightDto flight)
        {
            var dalFlight = _mapper.Map<Domain.Flight>(flight);
            try
            {
                await _flightRepository.UpdateAsync(dalFlight);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update Async {ex.Message}");
                return false;
            }
           
            return true;
        }
    }
}
