using CsvHelper;
using CsvHelper.Configuration;

using Microsoft.EntityFrameworkCore;

using SuttonP.MeterReadings.Domain;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SuttonP.MeterReadings.Data
{
    public class MeterReadingsContext : DbContext
    {
        public MeterReadingsContext(DbContextOptions<MeterReadingsContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<MeterReading> MetersReadings => Set<MeterReading>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seedAccounts = GetSeedAccounts();
            modelBuilder.Entity<Account>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Account>().HasData(seedAccounts);
            modelBuilder.Entity<MeterReading>().HasKey(k => new { k.AccountId, k.Taken });
            modelBuilder.Entity<MeterReading>()
                .Property(p => p.Value)
                .HasMaxLength(5)
                .IsFixedLength();
        }

        private List<Account> GetSeedAccounts()
        {
            using StreamReader inputReader = File.OpenText(@"C:\Users\GBPhi\source\repos\ensek\SuttonP.MeterReadings.Interview\DataFiles\Test_Accounts.csv");
            CsvConfiguration csvConfiguration = new (CultureInfo.InvariantCulture);
            using CsvReader csvReader = new(inputReader, csvConfiguration);
            csvReader.Context.RegisterClassMap<AccountMap>();
            return csvReader.GetRecords<Account>().ToList();
        }
    }
}
