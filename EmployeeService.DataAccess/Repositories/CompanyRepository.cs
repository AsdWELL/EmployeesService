using Dapper;
using EmployeeService.DataAccess.Interfaces.Repositories;
using EmployeeService.Domain.Entities;
using System.Data;

namespace EmployeeService.DataAccess.Repositories
{
    public class CompanyRepository(IDbConnection dbConnection) : ICompanyRepository
    {
        public async Task<bool> IsCompanyExists(int id)
        {
            return await dbConnection.ExecuteScalarAsync<bool>(Sql.IsCompanyExists, new { Id = id });
        }

        public async Task<int> AddCompany(Company company)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<int>(Sql.AddCompany, company);
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return [.. await dbConnection.QueryAsync<Company>(Sql.GetAllCompanies)];
        }

        public async Task<Company?> GetCompanyById(int id)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<Company>(Sql.GetCompanyById, new { Id = id });
        }

        public async Task DeleteCompanyById(int id)
        {
            await dbConnection.ExecuteAsync(Sql.DeleteCompany, new { Id = id });
        }

        public async Task UpdateCompany(Company company)
        {
            await dbConnection.ExecuteAsync(Sql.UpdateCompany, company);
        }
    }
}
