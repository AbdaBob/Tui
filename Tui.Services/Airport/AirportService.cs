using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Tui.Infrastructure.Airport;

namespace Tui.Services.Airport
{
    /// <summary>
    /// Airport service
    /// Handling all about airports
    /// </summary>
    
    public class AirportService : IAirportService
    {
        private IAirportRepository _airportRepository;
        private IMapper _mapper;

        public AirportService(IAirportRepository repository, IMapper mapper)
        {
            _airportRepository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all airports
        /// </summary>
        /// <returns>AirporttDtos</returns>

        public async Task<List<AirportDto>> GetAllAsync()
        {
            var airports = await _airportRepository.GetAllAsync();
            return airports.Select(a => _mapper.Map<AirportDto>(a)).ToList();
        }

        /// <summary>
        /// Get one airport
        /// </summary>
        /// <param name="id">airportt id</param>
        /// <returns>Airport dto</returns>

        public async Task<AirportDto> GetAsync(int id)
        {
            var airport = await _airportRepository.GetAsync(ap => ap.Id == id);
            return _mapper.Map<AirportDto>(airport);
        }
    }
}
