using System;

namespace SuttonP.MeterReadings.API.Models
{
    public class MeterReadingCSV
    {
        public int AccountId { get; set; }
        public DateTime Taken { get; set; }
        public string Value { get; set; }
    }
}
