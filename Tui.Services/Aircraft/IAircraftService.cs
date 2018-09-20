using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tui.Services.Aircraft
{
   public interface IAircraftService
    {
        Task<List<AircraftDto>> GetAllAsync();
        Task<AircraftDto> GetAsync(int id);
    }
}
