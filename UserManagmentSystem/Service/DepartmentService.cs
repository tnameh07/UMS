using Microsoft.EntityFrameworkCore;
using UserManagmentSystem.Data;
using UserManagmentSystem.Models.Entities;
using UserManagmentSystem.Models.ViewModel;

namespace UserManagmentSystem.Service
{
    public class DepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task CreateDepartmentAsync(DepartmentViewModel model, int createdByAdminId)
        {
            var department = new Department
            {
                DepartmentName = model.DepartmentName!,
                IsActive = model.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatedByAdminId = createdByAdminId,
                LastModifiedByAdminId = createdByAdminId
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(int id, DepartmentViewModel model, int modifiedByAdminId)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                department.DepartmentName = model.DepartmentName!;
                department.IsActive = model.IsActive;
                department.UpdatedAt = DateTime.UtcNow;
                department.LastModifiedByAdminId = modifiedByAdminId;
                _context.Departments.Update(department);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}