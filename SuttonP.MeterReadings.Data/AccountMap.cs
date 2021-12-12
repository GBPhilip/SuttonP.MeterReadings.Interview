using CsvHelper.Configuration;

using SuttonP.MeterReadings.Domain;

using System.Globalization;

namespace SuttonP.MeterReadings.Data
{
    internal class AccountMap: ClassMap<Account>
    {
        public AccountMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(p => p.Id).Name("AccountId");
        }
    }
}
