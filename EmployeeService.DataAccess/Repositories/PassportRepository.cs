using Dapper;
using EmployeeService.Application.Interfaces.Repositories;
using EmployeeService.Domain.Entities;
using System.Data;

namespace EmployeeService.DataAccess.Repositories
{
    public class PassportRepository(IDbConnection dbConnection) : IPassportRepository
    {
        public async Task<int> AddPassport(Passport passport)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<int>(Sql.AddPassport, passport);
        }

        public async Task<Passport?> GetPassportById(int id)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<Passport>(Sql.GetPassportById, new { Id = id });
        }

        public async Task DeletePassportById(int id)
        {
            await dbConnection.ExecuteAsync(Sql.DeletePassport, new { Id = id });
        }
    }
}
