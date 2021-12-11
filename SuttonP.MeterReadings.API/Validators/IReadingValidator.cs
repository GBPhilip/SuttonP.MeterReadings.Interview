using SuttonP.MeterReadings.API.Models;

namespace SuttonP.MeterReadings.API.Validators
{
    public interface IReadingValidator
    {
        bool IsValid(MeterReadingCSV meterReading);
    }
}