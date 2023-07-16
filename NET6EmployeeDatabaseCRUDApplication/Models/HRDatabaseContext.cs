using Microsoft.EntityFrameworkCore;
using NET6EmployeeDatabaseCRUDApplication.Models;
namespace NET6EmployeeDatabaseCRUDApplication.Models
{
    public class HRDatabaseContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4EKG6BP\SQL2022;
                              Initial Catalog=CRUD;
                              Integrated Security=SSPI;TrustServerCertificate=True;"
            );
        }
    }
}
