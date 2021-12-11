using SuttonP.MeterReadings.API.Models;

namespace SuttonP.MeterReadings.API.Validators
{
    public class ReadingValidator : IReadingValidator
    {
        public bool IsValid(MeterReadingCSV meterReading)
        {
            return true;
        }
    }
}
