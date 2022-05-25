using AcademyA_CDO.Week6.EsTicket.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyA_CDO.Week6.EsTicket.Core.EF.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.CategoryName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(c => c.Tickets)
                .WithOne(t => t.Category);
        }
    }
}
