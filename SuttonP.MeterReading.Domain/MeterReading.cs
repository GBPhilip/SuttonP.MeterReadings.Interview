﻿using System;

namespace SuttonP.MeterReadings.Domain
{
    public class MeterReading
    {
        public int AccountId { get; set; }
        public DateTime Taken { get; set; }
        public int Value { get; set; }
    }
}
