using AutoMapper;

using CsvHelper;
using CsvHelper.Configuration;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SuttonP.MeterReadings.API.Models;
using SuttonP.MeterReadings.API.Validators;
using SuttonP.MeterReadings.Data;
using SuttonP.MeterReadings.Domain;

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace SuttonP.MeterReadings.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterReadingUploadsController : ControllerBase
    {
        private readonly ILogger<MeterReadingUploadsController> logger;
        private readonly IMapper mapper;
        private readonly IRepository repository;
        private readonly IReadingValidator meterReadingValidator;


        public MeterReadingUploadsController(ILogger<MeterReadingUploadsController> logger
            , IMapper mapper
            , IReadingValidator meterReadingValidator
            , IRepository repository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.meterReadingValidator = meterReadingValidator;
            this.repository = repository;
        }

        public IReadingValidator MeterReadingValidator { get; }

        [HttpPost]
        public async Task<IActionResult> LoadReadings(MeterFileUploadDto filename)
        {
            int validReadings = 0;
            int invalidReadings = 0;
            var meterReadings = GetMeterReadings(filename);
            List<MeterReading> validMeterReadings = new();
            foreach (var meterReading in meterReadings)
            {
                if (meterReadingValidator.IsValid(meterReading))
                {
                    validMeterReadings.Add(mapper.Map<MeterReading>(meterReading));
                    validReadings++;
                }
                else
                {
                    invalidReadings++;
                }
            }
            repository.Save(validMeterReadings);
        }

        private IEnumerable<MeterReadingCSV> GetMeterReadings(MeterFileUploadDto filename)
        {
            using StreamReader inputReader = File.OpenText(@"C:\Users\GBPhi\source\repos\ensek\SuttonP.MeterReadings.Interview\DataFiles\Test_Accounts.csv");
            CsvConfiguration csvConfiguration = new(CultureInfo.InvariantCulture);
            using CsvReader csvReader = new(inputReader, csvConfiguration);
            return csvReader.GetRecords<MeterReadingCSV>();
        }
    }
}
