using CsvHelper.Configuration;

using SuttonP.MeterReadings.Domain;

namespace SuttonP.MeterReadings.API.Maps
{
    public class MeterReadingMap:ClassMap<MeterReading>
    {
        public MeterReadingMap()
        {
            Map(p => p.Taken).Name("MeterReadingDateTime");
            Map(p => p.Value).Name("MeterReadingValue");
        }
    }
}
