using CsvHelper;
using CsvHelper.Configuration;

using SuttonP.MeterReadings.API.Maps;
using SuttonP.MeterReadings.API.Models;

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SuttonP.MeterReadings.API
{
    public class MeterReadingFileReader : IMeterReadingFileReader
    {
        public List<MeterReadingCSV> GetMeterReadings(string filename)
        {
            using StreamReader inputReader = File.OpenText(filename);
            CsvConfiguration csvConfiguration = new(CultureInfo.InvariantCulture);
            using CsvReader csvReader = new(inputReader, csvConfiguration);
            csvReader.Context.RegisterClassMap<MeterReadingMap>();
            return csvReader.GetRecords<MeterReadingCSV>().ToList();
        }
    }
}
