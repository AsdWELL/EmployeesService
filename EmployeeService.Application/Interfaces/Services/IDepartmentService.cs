using EmployeeService.Application.Dto.Department;

namespace EmployeeService.Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<int> AddDepartment(AddDepartmentRequest request);

        Task<DepartmentResponse> GetDepartmentById(int id);

        Task<List<DepartmentResponse>> GetAllDepartments();

        Task UpdateDepartment(UpdateDepartmentRequest request);

        Task DeleteDepartmentById(int id);
    }
}
