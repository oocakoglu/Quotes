using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuotesDemo.Core.Models;

namespace QuotesDemo.Data.Configurations
{

    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("DemoAuthor");

            builder.HasKey(m => m.Id);                

            builder.Property(e => e.Name).HasMaxLength(150);

            builder.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken();

        }
    }
}
