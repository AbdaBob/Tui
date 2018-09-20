using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tui.Infrastructure.Aircraft;
using System.Linq;

namespace Tui.Services.Aircraft
{
    public class AircraftService : IAircraftService
    {
        private IAircraftRepository _aircraftRepository;
        private IMapper _mapper;
        public AircraftService(IAircraftRepository repository, IMapper mapper)
        {
            _aircraftRepository = repository;
            _mapper = mapper;
        }
        public async Task<List<AircraftDto>> GetAllAsync()
        {
            var aircrafts = await _aircraftRepository.GetAllAsync();
            return aircrafts.Select(a => _mapper.Map<AircraftDto>(a)).ToList();
        }

        public async Task<AircraftDto> GetAsync(int id)
        {
            var airport = await _aircraftRepository.GetAsync(ap => ap.Id == id);
            return _mapper.Map<AircraftDto>(airport);
        }
    }
}
