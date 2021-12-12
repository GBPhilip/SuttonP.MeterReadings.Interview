using System;

namespace SuttonP.MeterReadings.Domain
{
    public class MeterReading
    {
        public string AccountId { get; set; }
        public DateTime Taken { get; set; }
        public string Value { get; set; }
    }
}
