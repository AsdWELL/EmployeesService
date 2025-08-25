using EmployeeService.Application.Dto.Employee;

namespace EmployeeService.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<int> AddEmployee(AddEmployeeRequest request);

        Task<EmployeeResponse> GetEmployeeById(int id);

        Task<List<EmployeeResponse>> GetEmployeesByCompanyId(int companyId);

        Task<List<EmployeeResponse>> GetEmployeesByCompanyIdAndDepartmentId(int companyId, int departmentId);

        Task<List<EmployeeResponse>> GetAllEmployees();

        Task UpdateEmployee(UpdateEmployeeRequest request);

        Task DeleteEmployeeById(int id);
    }
}
