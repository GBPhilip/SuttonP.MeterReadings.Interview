using SuttonP.MeterReadings.API.Models;

using System.Collections.Generic;

namespace SuttonP.MeterReadings.API
{
    public interface IMeterReadingsProcessor
    {
        (int validReadings, int invalidReadings) Process(List<MeterReadingCSV> meterReadings);
    }
}