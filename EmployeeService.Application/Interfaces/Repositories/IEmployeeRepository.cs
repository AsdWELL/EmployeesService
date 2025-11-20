using EmployeeService.Application.Dto.Employee;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> IsEmployeeExists(int id);

        Task<int> AddEmployee(Employee employee);

        Task<Employee?> GetEmployeeById(int id);

        Task<EmployeeResponse?> GetEmployeeDetailsById(int id);

        Task<List<EmployeeResponse>> GetEmployeesByCompanyId(int companyId);

        Task<List<EmployeeResponse>> GetEmployeesByCompanyIdAndDepartmentId(int companyId, int departmentId);
        
        Task<List<EmployeeResponse>> GetAllEmployees();

        Task UpdateEmployee(Employee employee);

        Task DeleteEmployeeById(int id);
    }
}
