using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Data.Configurations
{
    public class GroupsConfiguration : IEntityTypeConfiguration<Groups>
    {
        public void Configure(EntityTypeBuilder<Groups> builder)
        {
            builder.ToTable("Groups");
            builder.HasKey(e => e.IdGroup);

            builder.Property(e => e.IdGroup)
                .HasColumnName("Id_group");

            builder.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("Date");

            builder.Property(e => e.NameGroup)
                .HasColumnName("NameGroup")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
