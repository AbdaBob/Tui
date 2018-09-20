using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tui.Services.Aircraft
{
    public class AircraftProfile : Profile
    {
        public AircraftProfile()
        {
            CreateMap<Domain.Aircraft, AircraftDto>();
        }
    }
}
