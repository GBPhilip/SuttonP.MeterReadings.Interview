using SuttonP.MeterReadings.Domain;

using System.Collections.Generic;

namespace SuttonP.MeterReadings.Data
{
    public class Repository : IRepository
    {
        private readonly MeterReadingsContext context;

        public Repository(MeterReadingsContext context)
        {
            this.context = context;
        }

        public void Save(IEnumerable<MeterReading> readings)
        {
            context.MetersReadings.AddRange(readings);
            context.SaveChanges();
        }
    }
}
