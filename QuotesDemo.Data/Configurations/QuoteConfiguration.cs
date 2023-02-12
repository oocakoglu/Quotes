using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuotesDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Data.Configurations
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.ToTable("DemoQuote");

            builder.HasKey(m => m.Id);

            builder.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();

            //**Foreign Key
            builder.HasOne(d => d.Author)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_Author");

        }
    }
}
