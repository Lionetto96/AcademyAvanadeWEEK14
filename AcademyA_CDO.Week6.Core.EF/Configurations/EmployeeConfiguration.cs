using AcademyA_CDO.Week6.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyA_CDO.Week6.Core.EF.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(c => c.Id);
            
            builder
                .Property(c => c.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(c => c.Birthdate)
                .IsRequired();
            builder
                .Property(c => c.EmployeeCode)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(c => c.Level)
                .HasMaxLength(10);


        }
    }
}
