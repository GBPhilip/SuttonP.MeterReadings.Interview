using SuttonP.MeterReadings.Domain;

using System.Collections.Generic;

namespace SuttonP.MeterReadings.Data
{
    public interface IRepository
    {
        Account GetAccountById(string id);
        void Save(IEnumerable<MeterReading> readings);
    }
}