using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBuy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBuy.Infra.Data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.ToTable("person");

            builder.HasKey(x => x.Id);

            builder.Property(x =>x.Id)
                .HasColumnName("idperson")
                .UseIdentityColumn();

            builder.Property(x => x.Ssn)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasMany(c => c.Purchases)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonId);

        }
    }
}
