using CsvHelper;
using CsvHelper.Configuration;

using Microsoft.EntityFrameworkCore;

using SuttonP.MeterReading.Domain;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace SuttonP.MeterReadings.Data
{
    public class MeterReadingsContext : DbContext
    {
        public MeterReadingsContext(DbContextOptions<MeterReadingsContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts => Set<Account>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seedAccounts = GetSeedAccounts();
            modelBuilder.Entity<Account>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Account>().HasData(seedAccounts);

        }

        private IEnumerable<Account> GetSeedAccounts()
        {
            using StreamReader inputReader = File.OpenText(@"C:\Users\GBPhi\source\repos\ensek\SuttonP.MeterReadings.Interview\DataFiles\Test_Accounts.csv");
            CsvConfiguration csvConfiguration = new (CultureInfo.InvariantCulture);
            using CsvReader csvReader = new(inputReader, csvConfiguration);
            var accounts = csvReader.GetRecords<Account>();
            return accounts;

        }
    }
}
