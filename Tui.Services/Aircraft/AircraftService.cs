using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tui.Infrastructure.Aircraft;
using System.Linq;

namespace Tui.Services.Aircraft
{
    /// <summary>
    /// Aircraft service
    /// Handling all about aircrafts
    /// </summary>
    public class AircraftService : IAircraftService
    {
        private IAircraftRepository _aircraftRepository;
        private IMapper _mapper;


        public AircraftService(IAircraftRepository repository, IMapper mapper)
        {
            _aircraftRepository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all aircrafts
        /// </summary>
        /// <returns>AircraftDtos</returns>
        public async Task<List<AircraftDto>> GetAllAsync()
        {
            var aircrafts = await _aircraftRepository.GetAllAsync();
            return aircrafts.Select(a => _mapper.Map<AircraftDto>(a)).ToList();
        }

        /// <summary>
        /// Get one aircraft
        /// </summary>
        /// <param name="id">aircraft id</param>
        /// <returns>Aircraft dto</returns>
        public async Task<AircraftDto> GetAsync(int id)
        {
            var airport = await _aircraftRepository.GetAsync(ap => ap.Id == id);
            return _mapper.Map<AircraftDto>(airport);
        }
    }
}
