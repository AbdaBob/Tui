using AutoMapper;

namespace Tui.Services.Flight
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<FlightDto, Domain.Flight>();              

            CreateMap<UpdateFlightDto, Domain.Flight>();

            CreateMap<Domain.Flight, RequestFlightDto>()
                .ForMember(dest => dest.Departure, source => source.MapFrom(s => s.DepartureAirport.Name))
                .ForMember(dest => dest.Destination, source => source.MapFrom(s => s.DestinationAirport.Name))
                .ForMember(dest => dest.Aircraft, source => source.MapFrom(s => s.Aircraft.Name))

                ;
        }
    }
}
