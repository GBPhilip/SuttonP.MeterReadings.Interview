using SuttonP.MeterReadings.Domain;

using System;
using System.Collections.Generic;
using System.Linq;

namespace SuttonP.MeterReadings.Data
{
    public class Repository : IRepository
    {
        private readonly MeterReadingsContext context;

        public Repository(MeterReadingsContext context)
        {
            this.context = context;
        }

        public void Save(MeterReading reading)
        {
            context.MetersReadings.Add(reading);
            context.SaveChanges();
        }

        public bool ExistMeterReading(string account, DateTime taken)
        {
            return context.MetersReadings.Any(x => x.AccountId == account && x.Taken == taken);
        }

        public Account GetAccountById(string id)
        {
            return context.Accounts.SingleOrDefault(x => x.Id == id);
        }
    }
}
