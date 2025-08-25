using EmployeeService.Application.Dto.Company;
using EmployeeService.Application.Exceptions.NotFoundExceptions;
using EmployeeService.Application.Interfaces.Services;
using EmployeeService.Application.Mappers;
using EmployeeService.Application.Validators;
using EmployeeService.DataAccess.Interfaces.Repositories;

namespace EmployeeService.Application.Services
{
    public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
    {
        private async Task ThrowIfCompanyNotExists(int id)
        {
            if (!await companyRepository.IsCompanyExists(id))
                throw new CompanyNotFoundException(id);
        }
        
        public async Task<int> AddCompany(AddCompanyRequest request)
        {
            request.ValidateAddRequest();
            
            return await companyRepository.AddCompany(request.MapToDomain());
        }

        public async Task<List<CompanyResponse>> GetAllCompanies()
        {
            var companies = await companyRepository.GetAllCompanies();

            return companies.MapToResponseList();
        }

        public async Task<CompanyResponse> GetCompanyById(int id)
        {
            var company = await companyRepository.GetCompanyById(id)
                ?? throw new CompanyNotFoundException(id);

            return company.MapToDto();
        }

        public async Task UpdateCompany(UpdateCompanyRequest request)
        {
            await ThrowIfCompanyNotExists(request.Id);

            request.ValidateUpdateRequest();
            
            await companyRepository.UpdateCompany(request.MapToDomain());
        }

        public async Task DeleteCompanyById(int id)
        {
            await ThrowIfCompanyNotExists(id);

            await companyRepository.DeleteCompanyById(id);
        }
    }
}
