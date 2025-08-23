using EmployeeService.Domain.Entities;

namespace EmployeeService.DataAccess.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task<bool> IsCompanyExists(int id);
        
        Task<int> AddCompany(Company company);

        Task<Company?> GetCompanyById(int id);

        Task<List<Company>> GetAllCompanies();

        Task UpdateCompany(Company company);

        Task DeleteCompanyById(int id);
    }
}
