using AutoMapper;

using SuttonP.MeterReadings.API.Models;
using SuttonP.MeterReadings.Domain;

using System;

namespace SuttonP.MeterReadings.API.Profiles
{
    public class MeterReadingProfile : Profile
    {
        public MeterReadingProfile()
        {
            CreateMap<MeterReadingCSV, MeterReading>()
                .ForMember(
                dest => dest.Value,
                opt => opt.MapFrom(src => int.Parse(src.Value)))
                .ForMember(
                dest => dest.Taken,
                opt => opt.MapFrom(src => DateTime.Parse(src.Taken)));
        }

    }
}
