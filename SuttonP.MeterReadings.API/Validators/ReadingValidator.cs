using SuttonP.MeterReadings.API.Models;
using SuttonP.MeterReadings.Data;

namespace SuttonP.MeterReadings.API.Validators
{
    public class ReadingValidator : IReadingValidator
    {
        private readonly IRepository repository;

        public ReadingValidator(IRepository repository)
        {
            this.repository = repository;
        }
        public bool IsValid(MeterReadingCSV meterReading)
        {
            if (!int.TryParse(meterReading.Value, out int value)) return false;
            if (value < 0) return false;
            return repository.GetAccountById(meterReading.AccountId) != null;
        }
    }
}
