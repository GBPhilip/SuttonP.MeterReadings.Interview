using SuttonP.MeterReadings.API.Models;
using SuttonP.MeterReadings.Data;

using System.Text.RegularExpressions;

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
            if (!Regex.Match(meterReading.Value, @"^[0-9]{5}$").Success) return false;
            return repository.GetAccountById(meterReading.AccountId) != null;
        }
    }
}
