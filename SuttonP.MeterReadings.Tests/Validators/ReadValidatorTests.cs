using SuttonP.MeterReadings.API.Models;
using SuttonP.MeterReadings.API.Validators;
using SuttonP.MeterReadings.Data;

using System;

using Xunit;

using Moq;
using SuttonP.MeterReadings.Domain;

namespace SuttonP.MeterReadings.Tests
{
    public class ReadValidatorTests
    {
        [Fact]
        public void When_Reading_Is_Not_An_Integer_Return_False()
        {
            MeterReadingCSV reading = new()
            {
                AccountId = "1234",
                Taken = new DateTime(2020, 10, 10).ToString(),
                Value = "123.2"
            };
            var account = GetAccount();

            Mock<IRepository> mockRepository = new();
            mockRepository.Setup(x => x.GetAccountById(reading.AccountId)).Returns(account);
            ReadingValidator sut = new(mockRepository.Object);

            var result = sut.IsValid(reading);

            Assert.False(result);
        }

        [Fact]
        public void When_Reading_Is_Negative_Return_False()
        {
            MeterReadingCSV reading = new()
            {
                AccountId = "1234",
                Taken = new DateTime(2020, 10, 10).ToString(),
                Value = "-5"
            };
            var account = GetAccount();
            Mock<IRepository> mockRepository = new();
            mockRepository.Setup(x => x.GetAccountById(reading.AccountId)).Returns(account);
            ReadingValidator sut = new(mockRepository.Object);

            var result = sut.IsValid(reading);

            Assert.False(result);
        }

        [Fact]
        public void When_Account_Does_Not_Exist_Return_False()
        {
            MeterReadingCSV reading = new();
            reading.AccountId = "1234";
            reading.Taken = new DateTime(2020, 10, 10).ToString();
            reading.Value = "6";

            Mock<IRepository> mockRepository = new();
            mockRepository.Setup(x => x.GetAccountById(reading.AccountId)).Returns((Account)null);
            ReadingValidator sut = new(mockRepository.Object);

            var result = sut.IsValid(reading);
            Assert.False(result);
        }
        [Fact]
        public void When_Account_Exist_And_Reading_Positive_Return_True()
        {
            MeterReadingCSV reading = new();
            reading.AccountId = "1234";
            reading.Taken = new DateTime(2020, 10, 10).ToString();
            reading.Value = "6";
            var account = GetAccount();
            Mock<IRepository> mockRepository = new();
            mockRepository.Setup(x => x.GetAccountById(reading.AccountId)).Returns(account);
            ReadingValidator sut = new(mockRepository.Object);

            var result = sut.IsValid(reading);
            Assert.True(result);
        }

        private Account GetAccount()
        {
            return new Account
            {
                FirstName = "Philip",
                LastName = "Sutton",
                Id = "1234"
            };

        }

    }
}
