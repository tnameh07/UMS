using Microsoft.EntityFrameworkCore;
using UserManagmentSystem.Data;
using UserManagmentSystem.Models.Entities;
using UserManagmentSystem.Models.ViewModel;
using BCrypt.Net;

public class EmployeeService
{
    private readonly AppDbContext _context;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task CreateEmployeeAsync(EmployeeViewModel model, int adminId)
    {
        var employee = new Employee
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            UserType = model.UserType,
            PasswordHash = HashPassword("abc123"),
            MobileNumber = model.MobileNumber,
            DepartmentId = model.DepartmentId,
            RoleId = model.RoleId,
            IsActive = model.IsActive,
            StreetAddress = model.StreetAddress,
            City = model.City,
            State = model.State,
            PostalCode = model.PostalCode,
            Country = model.Country,
            CreatedAt = DateTime.UtcNow,
            CreatedByAdminId = adminId,
            IsDeleted = false
        };

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        //return employee;
    }

    private static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
       
    }
    public async Task<Employee> UpdateEmployeeAsync(int id, EmployeeViewModel model, int adminId)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            throw new Exception("Employee not found");
        }

        employee.FirstName = model.FirstName;
        employee.LastName = model.LastName;
        employee.Email = model.Email;
        employee.UserType = model.UserType;
        employee.MobileNumber = model.MobileNumber;
        employee.DepartmentId = model.DepartmentId;
        employee.RoleId = model.RoleId;
        employee.IsActive = model.IsActive;
        employee.StreetAddress = model.StreetAddress;
        employee.City = model.City;
        employee.State = model.State;
        employee.PostalCode = model.PostalCode;
        employee.Country = model.Country;
        employee.UpdatedAt = DateTime.UtcNow;
        employee.LastModifiedByAdminId = adminId;

        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            throw new Exception("Employee not found");
        }

        employee.IsDeleted = true;
        await _context.SaveChangesAsync();
    }
}