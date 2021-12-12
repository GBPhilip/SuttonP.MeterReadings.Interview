using SuttonP.MeterReadings.API.Models;
using SuttonP.MeterReadings.API.Validators;
using SuttonP.MeterReadings.Data;
using SuttonP.MeterReadings.Domain;

using System;

using Xunit;
 
using Moq;

namespace SuttonP.MeterReadings.Tests
{
    public class ReadValidatorTests
    {
        [Fact]
        public void When_Reading_Is_Fewer_than_5_Digits_Return_False()
        {
            MeterReadingCSV reading = new()
            {
                AccountId = "1234",
                Taken = new DateTime(2020, 10, 10),
                Value = "1232"
            };
            var account = GetAccount();

            Mock<IRepository> mockRepository = new();
            mockRepository.Setup(x => x.GetAccountById(reading.AccountId)).Returns(account);
            ReadingValidator sut = new(mockRepository.Object);

            var result = sut.IsValid(reading);

            Assert.False(result);
        }

        [Fact]
        public void When_Reading_Is_Greater_Than_5_Digits_Return_False()
        {
            MeterReadingCSV reading = new()
            {
                AccountId = "1234",
                Taken = new DateTime(2020, 10, 10),
                Value = "123456"
            };
            var account = GetAccount();
            Mock<IRepository> mockRepository = new();
            mockRepository.Setup(x => x.GetAccountById(reading.AccountId)).Returns(account);
            ReadingValidator sut = new(mockRepository.Object);

            var result = sut.IsValid(reading);

            Assert.False(result);
        }

        [Fact]
        public void When_Reading_Is_Not_All_Digits_Return_False()
        {
            MeterReadingCSV reading = new()
            {
                AccountId = "1234",
                Taken = new DateTime(2020, 10, 10),
                Value = "1234G"
            };
            var account = GetAccount();
            Mock<IRepository> mockRepository = new();
            mockRepository.Setup(x => x.GetAccountById(reading.AccountId)).Returns(account);
            ReadingValidator sut = new(mockRepository.Object);

            var result = sut.IsValid(reading);

            Assert.False(result);
        }
        [Fact]
        public void When_Reading_Is_5_Digits_Return_True()
        {
            MeterReadingCSV reading = new()
            {
                AccountId = "1234",
                Taken = new DateTime(2020, 10, 10),
                Value = "12345"
            };
            var account = GetAccount();
            Mock<IRepository> mockRepository = new();
            mockRepository.Setup(x => x.GetAccountById(reading.AccountId)).Returns(account);
            ReadingValidator sut = new(mockRepository.Object);

            var result = sut.IsValid(reading);

            Assert.True(result);
        }

        [Fact]
        public void When_Account_Does_Not_Exist_Return_False()
        {
            MeterReadingCSV reading = new();
            reading.AccountId = "1234";
            reading.Taken = new DateTime(2020, 10, 10);
            reading.Value = "6";

            Mock<IRepository> mockRepository = new();
            mockRepository.Setup(x => x.GetAccountById(reading.AccountId)).Returns((Account)null);
            ReadingValidator sut = new(mockRepository.Object);

            var result = sut.IsValid(reading);
            Assert.False(result);
        }

        [Fact]
        public void When_Reading_Already_Exists_Return_False()
        {
            MeterReadingCSV reading = new();
            reading.AccountId = "1234";
            reading.Taken = new DateTime(2020, 10, 10);
            reading.Value = "11116";

            var account = GetAccount();
            Mock<IRepository> mockRepository = new();
            mockRepository.Setup(x => x.GetAccountById(reading.AccountId)).Returns(account);

            mockRepository.Setup(x => x.ExistMeterReading(reading.AccountId,reading.Taken)).Returns(true);
            ReadingValidator sut = new(mockRepository.Object);


            var result = sut.IsValid(reading);
            Assert.False(result);
        }


        [Fact]
        public void When_Account_Exist_And_Reading_Positive_Return_True()
        {
            MeterReadingCSV reading = new();
            reading.AccountId = "1234";
            reading.Taken = new DateTime(2020, 10, 10);
            reading.Value = "12356";
            var account = GetAccount();
            Mock<IRepository> mockRepository = new();
            mockRepository.Setup(x => x.GetAccountById(reading.AccountId)).Returns(account);

            mockRepository.Setup(x => x.ExistMeterReading(reading.AccountId, reading.Taken)).Returns(false);

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
