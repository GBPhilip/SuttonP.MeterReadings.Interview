using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SuttonP.MeterReadings.API.Models;
using SuttonP.MeterReadings.API.Validators;
using SuttonP.MeterReadings.Data;
using SuttonP.MeterReadings.Domain;

using System.Collections.Generic;

namespace SuttonP.MeterReadings.API.Controllers
{
    [ApiController]
    [Route("meter-reading-uploads")]
    public class MeterReadingUploadsController : ControllerBase
    {
        private readonly ILogger<MeterReadingUploadsController> logger;
        private readonly IMeterReadingFileReader fileReader;
        private readonly IMeterReadingsProcessor meterReadingsProcessor;

        public MeterReadingUploadsController(ILogger<MeterReadingUploadsController> logger
            , IMeterReadingFileReader fileReader
            , IMeterReadingsProcessor meterReadingsProcessor)
        {
            this.logger = logger;
            this.fileReader = fileReader;
            this.meterReadingsProcessor = meterReadingsProcessor;
        }

        [HttpPost]
        public ActionResult<UploadMeterReadingsResponseDTO> LoadReadings(MeterFileUploadDto fileupload)
        {
            if (!System.IO.File.Exists(fileupload.FileName)) 
                return BadRequest("File does not exist");
            var meterReadings = fileReader.GetMeterReadings(fileupload.FileName);
            (int validReadings, int invalidReadings) readings = meterReadingsProcessor.Process(meterReadings);
            
            return Ok(new UploadMeterReadingsResponseDTO 
            { InValidReadings = readings.invalidReadings, ValidReadings=readings.validReadings});
        }

    }
}
