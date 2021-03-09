using CivilManagement.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CivilManagement.DataAccess.Concrete.EntityFramework.Context
{
    public class CivilReportingContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("");
        }

        public DbSet<trInvoiceHeader> trInvoiceHeader{ get; set; }
        public DbSet<trInvoiceLine> trInvoiceLine{ get; set; }

    }
}
