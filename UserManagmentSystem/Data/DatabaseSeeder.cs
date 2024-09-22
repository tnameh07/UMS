using Microsoft.EntityFrameworkCore;
using UserManagmentSystem.Models.Entities;
using BCrypt.Net;
using System.Security.Cryptography;
using System.Text;
using System.Net.NetworkInformation;



namespace UserManagmentSystem.Data
{
    public static class DatabaseSeeder
    {
        public static async Task SeedData(AppDbContext context)
        {
            // Ensure the database is created
            await context.Database.EnsureCreatedAsync();

            if (!context.Departments.Any())
            {
                await SeedDepartments(context);
                await context.SaveChangesAsync();
            }

            if (!context.Roles.Any())
            {
                await SeedRoles(context);
                await context.SaveChangesAsync();
            }

            if (!context.Employees.Any())
            {
                await SeedAdminUser(context);
                await context.SaveChangesAsync();
            }

            //await context.SaveChangesAsync();
        }

        private static async Task SeedDepartments(AppDbContext context)
        {
            var departments = new[]
            {
                new Department { DepartmentName = "Administration", IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { DepartmentName = "Human Resources", IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { DepartmentName = "Information Technology", IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            };

            await context.Departments.AddRangeAsync(departments);
        }

        private static async Task SeedRoles(AppDbContext context)
        {
            var roles = new[]
            {
                new Role { RoleName = "System Admin" },
                new Role { RoleName = "HR Manager" },
                new Role { RoleName = "Project Manager" },
                new Role { RoleName = "Team Lead" },
                new Role { RoleName = "Employee" }
            };

            await context.Roles.AddRangeAsync(roles);
        }

        private static async Task SeedAdminUser(AppDbContext context)
        {
            var adminDepartment = await context.Departments.FirstOrDefaultAsync(d => d.DepartmentName == "Administration");
            var adminRole = await context.Roles.FirstOrDefaultAsync(r => r.RoleName == "System Admin");

            if (adminDepartment == null || adminRole == null)
            {
                throw new Exception("Admin department or role not found. Ensure departments and roles are seeded first.");
            }

            var adminUser = new Employee
            {
                FirstName = "Hemant",
                LastName = "Devde",
                Email = "admin@gmail.com",
                PasswordHash = HashPassword("admin123"),
                UserType = UserType.Admin,
                MobileNumber = "9876543210",
                DepartmentId = adminDepartment.DepartmentId,
                RoleId = adminRole.RoleId,
                IsActive = true,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                StreetAddress = "123 Admin St",
                City = "Indore",
                State = "Madhya Pradesh",
                PostalCode = "452001",
                Country = "India"
            };

            await context.Employees.AddAsync(adminUser);
        }

        // Simple password hashing method (for demonstration purposes only)
        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
            //using (var sha256 = SHA256.Create())
            //{
            //    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            //    return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            //}
        }
    }
}