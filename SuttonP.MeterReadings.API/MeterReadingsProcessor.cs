using AutoMapper;

using SuttonP.MeterReadings.API.Models;
using SuttonP.MeterReadings.API.Validators;
using SuttonP.MeterReadings.Data;
using SuttonP.MeterReadings.Domain;

using System.Collections.Generic;

namespace SuttonP.MeterReadings.API
{
    public class MeterReadingsProcessor : IMeterReadingsProcessor
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly IReadingValidator readingValidator;
        public MeterReadingsProcessor(IReadingValidator readingValidator
            , IRepository repository
            , IMapper mapper)
        {
            this.readingValidator = readingValidator;
            this.repository = repository;
            this.mapper = mapper;
        }
        public (int validReadings, int invalidReadings) Process(List<MeterReadingCSV> meterReadings)
        {
            int validReadings = 0;
            int invalidReadings = 0;

            foreach (var meterReading in meterReadings)
            {
                if (readingValidator.IsValid(meterReading))
                {
                    repository.Save(mapper.Map<MeterReading>(meterReading));
                    validReadings++;
                }
                else
                {
                    invalidReadings++;
                }
            }
            return (validReadings, invalidReadings);
        }
    }
}
