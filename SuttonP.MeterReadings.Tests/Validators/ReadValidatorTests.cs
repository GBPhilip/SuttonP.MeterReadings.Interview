using SuttonP.MeterReadings.API.Models;
using SuttonP.MeterReadings.API.Validators;

using System;

using Xunit;

namespace SuttonP.MeterReadings.Tests
{
    public class ReadValidatorTests
    {
        [Fact]
        public void When_Reading_Is_Not_An_Integer_Return_False()
        {
            MeterReadingCSV reading = new();
            reading.AccountId = "1234";
            reading.Taken = new DateTime(2020, 10, 10);
            reading.Value = "123.2";
            ReadingValidator sut = new();

            var result = sut.IsValid(reading);

            Assert.False(result);
        }
    }
}
