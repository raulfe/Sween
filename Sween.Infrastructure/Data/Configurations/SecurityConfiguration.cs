using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sween.Core.Entities;
using Sween.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Security");
            builder.HasKey(e => e.IdSecurity);

            builder.Property(e => e.IdSecurity)
                .HasColumnName("IdSecurity");


            builder.Property(e => e.User)
                .HasColumnName("User")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Rol)
                .HasColumnName("Rol")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasConversion(x => x.ToString(), x=>(RoleType)Enum.Parse(typeof(RoleType),x));
        }
    }
}
