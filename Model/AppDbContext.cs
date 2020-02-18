using System.ComponentModel.DataAnnotations.Schema;
using MasGlobal.Model;
using MasGLobal.Model;
using Microsoft.EntityFrameworkCore;
namespace MasGLobal.Model
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options)
            :base(options)
        {

        }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Employee>()
                .HasOne<SalaryType>(s => s.SalaryType)
                .WithMany(g => g.Employee)
                .HasForeignKey(s => s.salaryId);

                modelBuilder.Entity<SalaryType>().HasData(
                    new SalaryType { Id = 1, Name = "Hourly Salary" },
                    new SalaryType { Id = 2, Name = "Montly Salary" }
                );

                modelBuilder.Entity<Employee>().HasData(
                    new Employee { Id = 1, Name = "Mark" , salaryId = 1, salary= 1 },
                    new Employee { Id = 2, Name = "Stephan", salaryId = 2, salary = 1000 }
                );

           


        }
    }
}
