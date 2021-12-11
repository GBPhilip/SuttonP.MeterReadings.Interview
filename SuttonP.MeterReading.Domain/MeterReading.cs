using System;

namespace SuttonP.MeterReading.Domain
{
    internal class MeterReading
    {
        public int AccountId { get; set; }
        public DateTime Taken { get; set; }
        public string Value { get; set; }
    }
}
