using AcademyA_CDO.Week6.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyA_CDO.Week6.Core.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);
            builder
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(20);
            builder
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(u => u.Role)
                .IsRequired();
        }
    }
}
