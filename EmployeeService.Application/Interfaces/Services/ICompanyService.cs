using EmployeeService.Application.Dto.Company;

namespace EmployeeService.Application.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<int> AddCompany(AddCompanyRequest request);

        Task<CompanyResponse> GetCompanyById(int id);

        Task<List<CompanyResponse>> GetAllCompanies();

        Task UpdateCompany(UpdateCompanyRequest request);

        Task DeleteCompanyById(int id);
    }
}
