using AutoMapper;

using SuttonP.MeterReadings.API.Models;
using SuttonP.MeterReadings.Domain;

namespace SuttonP.MeterReadings.API.Profiles
{
    public class MeterReadingProfile : Profile
    {
        public MeterReadingProfile()
        {
            CreateMap<MeterReadingCSV, MeterReading>()
                .ForMember(
                dest => dest.Value,
                opt => opt.MapFrom(src => int.Parse(src.Value)));
        }

    }
}
