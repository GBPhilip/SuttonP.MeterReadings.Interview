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
            CreateMap<MeterReadingCSV, MeterReading>();
        }

    }
}
