using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

namespace Tui.Services.Airport
{
    public class AirportService : IAirportService
    {
        private Infrastructure.Airport.IAirportRepository _airportRepository;
        private IMapper _mapper;
        public AirportService(Infrastructure.Airport.IAirportRepository repository, IMapper mapper)
        {
            _airportRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<AirportDto>> GetAllAsync()
        {
            var airports = await _airportRepository.GetAllAsync();
            return airports.Select(a => _mapper.Map<AirportDto>(a)).ToList();
        }

        public async Task<AirportDto> GetAsync(int id)
        {
            var airport = await _airportRepository.GetAsync(ap => ap.Id == id);
            return _mapper.Map<AirportDto>(airport);

        }
    }
}
