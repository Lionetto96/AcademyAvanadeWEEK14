using AcademyA_CDO.Week6.EsTicket.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyA_CDO.Week6.EsTicket.Core.EF.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.NoteText)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .HasOne(n => n.Ticket)
                .WithMany(t => t.Notes);
        }
    }
}
