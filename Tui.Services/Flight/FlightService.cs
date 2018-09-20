using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tui.Infrastructure;
using Tui.Domain;
using Tui.Infrastructure.Flight;
using AutoMapper;
using System.Linq;

namespace Tui.Services.Flight
{
    public class FlightService : IFlightService
    {
        private IFlightRepository _flightRepository;
        private IMapper _mapper;
        public FlightService(IFlightRepository repository, IMapper mapper)
        {
            _flightRepository = repository;
            _mapper = mapper;
        }
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
                return false;
            }
        }

        public async Task<RequestFlightDto> GetAsync(int id)
        {
            var flight = await _flightRepository.GetAsync(f => f.Id == id);
            return flight != null ? _mapper.Map<RequestFlightDto>(flight) : null;
        }

        public async Task<List<RequestFlightDto>> GetAllAsync()
        {
            var fligths = await _flightRepository.GetAllAsync(null, "DestinationAirport", "DepartureAirport","Aircraft");
            return fligths.Select(c => _mapper.Map<RequestFlightDto>(c)).ToList();
        }

        public async Task<bool> UpdateAsync(UpdateFlightDto flight)
        {
            var dalFlight = _mapper.Map<Domain.Flight>(flight);
            try
            {
                await _flightRepository.UpdateAsync(dalFlight);
            }
            catch (Exception)
            {
                return false;
            }
           
            return true;
        }
    }
}
