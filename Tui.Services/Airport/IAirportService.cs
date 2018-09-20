using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tui.Services.Airport
{
    public interface IAirportService
    {
        Task<List<AirportDto>> GetAllAsync();
        Task<AirportDto> GetAsync(int id);
    }
}
