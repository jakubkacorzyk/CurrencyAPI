using CurrencyDAL.Configurations;
using CurrencyEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CurrencyDAL
{
    public class CurrencyDBContext : DbContext
    {
        public CurrencyDBContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }


        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
        }

    }
}
