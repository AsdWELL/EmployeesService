using Dapper;
using EmployeeService.DataAccess.Interfaces.Repositories;
using EmployeeService.Domain.Entities;
using System.Data;

namespace EmployeeService.DataAccess.Repositories
{
    public class EmployeeRepository(IDbConnection dbConnection) : IEmployeeRepository
    {
        public async Task<bool> IsEmployeeExists(int id)
        {
            return await dbConnection.ExecuteScalarAsync<bool>(Sql.IsEmployeeExists, new { Id = id });
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<int>(Sql.AddEmployee, employee);
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return [.. await dbConnection.QueryAsync<Employee>(Sql.GetAllEmployees)];
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<Employee>(Sql.GetEmployeeById, new { Id = id });
        }

        public async Task<List<Employee>> GetEmployeesByCompanyId(int companyId)
        {
            return [.. await dbConnection.QueryAsync<Employee>(Sql.GetEmployeesByCompanyId, new { CompanyId = companyId })];
        }

        public async Task<List<Employee>> GetEmployeesByCompanyIdAndDepartmentId(int companyId, int departmentId)
        {
            return [.. await dbConnection.QueryAsync<Employee>(Sql.GetEmployeesByCompanyIdAndDepartmentId,
                new { CompanyId = companyId, DepartmentId = departmentId })];
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await dbConnection.ExecuteAsync(Sql.UpdateEmployee, employee);
        }

        public async Task DeleteEmployeeById(int id)
        {
            await dbConnection.ExecuteAsync(Sql.DeleteEmployee, new { Id = id });
        }
    }
}
