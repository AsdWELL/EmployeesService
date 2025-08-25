using EmployeeService.Application.Dto.Company;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Application.Mappers
{
    public static class CompanyMapper
    {
        public static Company MapToDomain(this AddCompanyRequest request)
        {
            return new Company
            {
                Name = request.Name,
                Inn = request.Inn
            };
        }

        public static Company MapToDomain(this UpdateCompanyRequest request)
        {
            return new Company
            {
                Id = request.Id,
                Name = request.Name
            };
        }

        public static CompanyResponse MapToDto(this Company company)
        {
            return new CompanyResponse
            {
                Id = company.Id,
                Name = company.Name,
                Inn = company.Inn
            };
        }

        public static List<CompanyResponse> MapToResponseList(this List<Company> companies)
        {
            return companies.Select(MapToDto).ToList();
        }
    }
}
