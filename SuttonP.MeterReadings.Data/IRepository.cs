using SuttonP.MeterReadings.Domain;

using System.Collections.Generic;

namespace SuttonP.MeterReadings.Data
{
    public interface IRepository
    {
        void Save(IEnumerable<MeterReading> readings);
    }
}