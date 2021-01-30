using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Data.Configurations
{
    public class UsersGroupConfiguration : IEntityTypeConfiguration<UsersGroup>
    {
        public void Configure(EntityTypeBuilder<UsersGroup> builder)
        {
            builder.HasKey(e => e.IdUsergroup);

            builder.Property(e => e.IdUsergroup)
                .HasColumnName("Id_usergroup")
                .ValueGeneratedNever();

            builder.Property(e => e.IdGroup).HasColumnName("Id_group");

            builder.Property(e => e.IdUser).HasColumnName("Id_user");

            builder.HasOne(d => d.IdGroupNavigation)
                .WithMany(p => p.UsersGroup)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersGroup_Group");

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.UsersGroup)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersGroup_User");
        }
    }
}
