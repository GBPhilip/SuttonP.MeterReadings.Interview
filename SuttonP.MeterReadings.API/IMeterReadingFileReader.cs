using SuttonP.MeterReadings.API.Models;

using System.Collections.Generic;

namespace SuttonP.MeterReadings.API
{
    public interface IMeterReadingFileReader
    {
        List<MeterReadingCSV> GetMeterReadings(string filename);
    }
}