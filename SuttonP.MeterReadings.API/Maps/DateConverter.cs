using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

using System;

namespace SuttonP.MeterReadings.API.Maps
{
    public class DateConverter<T>:DefaultTypeConverter
    {
        public override object ConvertFromString(string text, 
            IReaderRow row, 
            MemberMapData memberMapData)
        {
            return DateTime.Parse(text);
        }
    }
}
