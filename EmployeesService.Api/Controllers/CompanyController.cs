using EmployeeService.Application.Dto.Company;
using EmployeeService.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesService.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CompanyController(ICompanyService companyService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] AddCompanyRequest request)
        {
            return Ok(await companyService.AddCompany(request));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCompanyById([FromRoute] int id)
        {
            return Ok(await companyService.GetCompanyById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            return Ok(await companyService.GetAllCompanies());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyRequest request)
        {
            await companyService.UpdateCompany(request);

            return Ok(request.Id);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCompanyById([FromRoute] int id)
        {
            await companyService.DeleteCompanyById(id);

            return Ok(id);
        }
    }
}
