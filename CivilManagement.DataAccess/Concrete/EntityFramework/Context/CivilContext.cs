using CivilManagement.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CivilManagement.DataAccess.Concrete.EntityFramework.Context
{
    public class CivilContext: DbContext
    {
        //public CivilContext(DbContextOptions<CivilContext> options) : base(options)
        //{
        //}

        public DbSet<trInvoiceHeader> trInvoiceHeader { get; set; }
        public DbSet<trInvoiceLine> trInvoiceLine { get; set; }
        public DbSet<cdItemDesc> cdItemDesc { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<prItemBarcode> prItemBarcode { get; set; }
        public DbSet<cvlReturnInvoiceControl> cvlReturnInvoiceControl { get; set; }
        public DbSet<ReturnInvoiceInfo> ReturnInvoiceInfos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(eb => eb.HasNoKey());
            modelBuilder.Entity<cdItemDesc>(eb => eb.HasNoKey());
            modelBuilder.Entity<prItemBarcode>(eb => eb.HasNoKey());
            modelBuilder.Entity<ReturnInvoiceInfo>(eb => eb.HasNoKey());
        }
    }
}