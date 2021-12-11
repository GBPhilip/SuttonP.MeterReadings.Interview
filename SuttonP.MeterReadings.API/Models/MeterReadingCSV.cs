using System;

namespace SuttonP.MeterReadings.API.Models
{
    public class MeterReadingCSV
    {
        public string AccountId { get; set; }
        public DateTime Taken { get; set; }
        public string Value { get; set; }
    }
}
