using EmployeeService.Domain.Entities;

namespace EmployeeService.DataAccess.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> IsEmployeeExists(int id);

        Task<int> AddEmployee(Employee employee);

        Task<Employee?> GetEmployeeById(int id);

        Task<List<Employee>> GetEmployeesByCompanyId(int companyId);

        Task<List<Employee>> GetEmployeesByCompanyIdAndDepartmentId(int companyId, int departmentId);
        
        Task<List<Employee>> GetAllEmployees();

        Task UpdateEmployee(Employee employee);

        Task DeleteEmployeeById(int id);
    }
}
