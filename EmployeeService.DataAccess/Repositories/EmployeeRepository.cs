using Dapper;
using EmployeeService.Application.Dto.Employee;
using EmployeeService.Application.Interfaces.Repositories;
using EmployeeService.Application.Mappers;
using EmployeeService.Domain.Entities;
using System.Data;

namespace EmployeeService.DataAccess.Repositories
{
    public class EmployeeRepository(IDbConnection dbConnection) : IEmployeeRepository
    {
        private async Task<List<EmployeeResponse>> GetEmployeesDetails(string sql, object? param = null)
        {
            return [.. await dbConnection.QueryAsync<Employee, Company, Passport, Department, EmployeeResponse>(
                sql,
                (employee, company, passport, department) =>
                    employee.MapToDto(company, passport, department),
                param)];
        }
        
        public async Task<bool> IsEmployeeExists(int id)
        {
            return await dbConnection.ExecuteScalarAsync<bool>(Sql.IsEmployeeExists, new { Id = id });
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<int>(Sql.AddEmployee, employee);
        }

        public async Task<List<EmployeeResponse>> GetAllEmployees()
        {
            return await GetEmployeesDetails(Sql.GetAllEmployees);
        }

        public async Task<EmployeeResponse?> GetEmployeeDetailsById(int id)
        {
            return (await GetEmployeesDetails(Sql.GetEmployeeDetails, new { Id = id })).FirstOrDefault();
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<Employee>(Sql.GetEmployeeById, new { Id = id });
        }

        public async Task<List<EmployeeResponse>> GetEmployeesByCompanyId(int companyId)
        {
            return await GetEmployeesDetails(Sql.GetEmployeesByCompanyId, new { CompanyId = companyId });
        }

        public async Task<List<EmployeeResponse>> GetEmployeesByCompanyIdAndDepartmentId(int companyId, int departmentId)
        {
            return await GetEmployeesDetails(Sql.GetEmployeesByCompanyIdAndDepartmentId,
                new { CompanyId = companyId, DepartmentId = departmentId });
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
