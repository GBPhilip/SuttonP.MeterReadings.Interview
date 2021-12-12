using SuttonP.MeterReadings.Domain;

using System;
using System.Collections.Generic;

namespace SuttonP.MeterReadings.Data
{
    public interface IRepository
    {
        bool ExistMeterReading(string account, DateTime taken);
        Account GetAccountById(string id);
        void Save(MeterReading reading);
    }
}