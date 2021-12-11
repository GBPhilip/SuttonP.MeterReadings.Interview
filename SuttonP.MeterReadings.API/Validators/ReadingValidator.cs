using SuttonP.MeterReadings.API.Models;

namespace SuttonP.MeterReadings.API.Validators
{
    public class ReadingValidator : IReadingValidator
    {
        public bool IsValid(MeterReadingCSV meterReading)
        {
            if (!int.TryParse(meterReading.Value, out int value)) return false;
            return value > -1;
        }
    }
}
