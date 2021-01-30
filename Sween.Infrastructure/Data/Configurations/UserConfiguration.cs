using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(e => e.IdUser);

            builder.Property(e => e.IdUser)
                .HasColumnName("Id_user");

            builder.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("Birthday");

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .HasColumnName("LastName")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            
            builder.Property(e => e.ImageURL)
                .HasColumnName("ImageURL")
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Nick)
                .HasColumnName("Nick")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Tel)
                .HasColumnName("Tel")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
