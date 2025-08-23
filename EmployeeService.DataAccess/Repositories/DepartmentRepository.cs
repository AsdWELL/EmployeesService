using Dapper;
using EmployeeService.DataAccess.Interfaces.Repositories;
using EmployeeService.Domain.Entities;
using System.Data;

namespace EmployeeService.DataAccess.Repositories
{
    public class DepartmentRepository(IDbConnection dbConnection) : IDepartmentRepository
    {
        public async Task<bool> IsDepartmentExists(int id)
        {
            return await dbConnection.ExecuteScalarAsync<bool>(Sql.IsDepartmentExists, new { Id = id });
        }

        public async Task<int> AddDepartment(Department department)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<int>(Sql.AddDepartment, department);
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return [.. await dbConnection.QueryAsync<Department>(Sql.GetAllDepartments)];
        }

        public async Task<Department?> GetDepartmentById(int id)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<Department>(Sql.GetDepartmentById, new { Id = id });
        }

        public async Task UpdateDepartment(Department department)
        {
            await dbConnection.ExecuteAsync(Sql.UpdateDepartment, department);
        }

        public async Task DeleteDepartmentById(int id)
        {
            await dbConnection.ExecuteAsync(Sql.DeleteDepartment, new { Id = id });
        }
    }
}
