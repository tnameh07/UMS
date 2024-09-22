
using UserManagmentSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace UserManagmentSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<LoginAttempt> LoginAttempts { get; set; }

        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }

      



    }
}