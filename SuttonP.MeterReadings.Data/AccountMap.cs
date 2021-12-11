using CsvHelper.Configuration;

using SuttonP.MeterReadings.Domain;

namespace SuttonP.MeterReadings.Data
{
    internal class AccountMap: ClassMap<Account>
    {
        public AccountMap()
        {
            Map(p => p.Id).Name("AccountId");
        }
    }
}
