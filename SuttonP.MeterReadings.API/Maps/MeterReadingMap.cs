using CsvHelper.Configuration;

using SuttonP.MeterReadings.API.Models;

namespace SuttonP.MeterReadings.API.Maps
{
    public class MeterReadingMap:ClassMap<MeterReadingCSV>
    {
        public MeterReadingMap()
        {
            Map(p => p.AccountId).Name("AccountId");
            Map(p => p.Taken).Name("MeterReadingDateTime");
            Map(p => p.Value).Name("MeterReadValue");
        }
    }
}
