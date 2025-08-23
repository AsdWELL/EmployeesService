using EmployeeService.Domain.Entities;

namespace EmployeeService.DataAccess.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<bool> IsDepartmentExists(int id);

        Task<int> AddDepartment(Department department);

        Task<Department?> GetDepartmentById(int id);

        Task<List<Department>> GetAllDepartments();

        Task UpdateDepartment(Department department);

        Task DeleteDepartmentById(int id);
    }
}
