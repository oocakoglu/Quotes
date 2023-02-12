using Microsoft.EntityFrameworkCore;
using QuotesDemo.Core.Models;
using QuotesDemo.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Data
{
    public class QuoteDbContext : DbContext
    {
        //public QuoteDbContext()
        //{
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //** If Not configured
        //        optionsBuilder.UseSqlServer("Data Source=OOCAKOGLU\\SQL2016;Initial Catalog=QUOTEDB;User Id=sa;Password=...;");
        //    }
        //}


        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Quote> Quotes { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public QuoteDbContext(DbContextOptions<QuoteDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());

            modelBuilder.ApplyConfiguration(new QuoteConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }


    }
}
