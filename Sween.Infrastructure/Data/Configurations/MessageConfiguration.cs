using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sween.Core.Entities;

namespace Sween.Infrastructure.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Messages>
    {
        public void Configure(EntityTypeBuilder<Messages> builder)
        {
            builder.ToTable("Messages");
            builder.HasKey(e => e.IdMessage);

            builder.Property(e => e.IdMessage)
                .HasColumnName("Id_message");

            builder.Property(e => e.Contain)
                .HasColumnName("Contain")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("Date");

            builder.Property(e => e.IdUser)
                .HasColumnName("Id_user")
                .HasColumnName("IdUser");

            builder.Property(e => e.Reaction)
                .HasColumnName("Reaction")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Type)
                .HasColumnName("Type")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.View)
                .HasColumnName("View")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Messages)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_User");
        }
    }
}
