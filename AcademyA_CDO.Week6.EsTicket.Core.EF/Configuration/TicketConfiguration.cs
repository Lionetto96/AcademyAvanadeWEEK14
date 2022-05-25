using AcademyA_CDO.Week6.EsTicket.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyA_CDO.Week6.EsTicket.Core.EF.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(t => t.Description)
                .HasMaxLength(600)
                .IsRequired();

            builder
                .HasMany(t => t.Notes)
                .WithOne(n => n.Ticket)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(t => t.Category)
                .WithMany(c => c.Tickets);
        }
    }
}
