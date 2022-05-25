using AcademyA_CDO.Week6.Core.EF.Configurations;
using AcademyA_CDO.Week6.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AcademyA_CDO.Week6.Core.EF
{
    public class EmployeeContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        public EmployeeContext() : base() { }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = "Server=tcp:academydemo.database.windows.net,1433;Initial Catalog=AcademyDemo;Persist Security Info=False;User ID=academy_admin;Password=P@s$w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        }
    }
}
