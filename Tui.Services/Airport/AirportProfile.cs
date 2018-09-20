using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tui.Services.Airport
{
    public class AirportProfile : Profile
    {
        public AirportProfile()
        {
            CreateMap<Domain.Airport, AirportDto>();
        }
    }
}
