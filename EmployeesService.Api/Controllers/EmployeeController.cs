using EmployeeService.Application.Dto.Employee;
using EmployeeService.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
namespace EmployeesService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
        {
            return Ok(await employeeService.AddEmployee(request));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            return Ok(await employeeService.GetEmployeeById(id));
        }

        [HttpGet("company/{companyId:int}")]
        public async Task<IActionResult> GetEmployeesByCompanyId([FromRoute] int companyId)
        {
            return Ok(await employeeService.GetEmployeesByCompanyId(companyId));
        }

        [HttpGet("company/{companyId:int}/department/{departmentId:int}")]
        public async Task<IActionResult> GetEmployeesByCompanyIdAndDepartmentId([FromRoute] int companyId, [FromRoute] int departmentId)
        {
            return Ok(await employeeService.GetEmployeesByCompanyIdAndDepartmentId(companyId, departmentId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await employeeService.GetAllEmployees());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest request)
        {
            await employeeService.UpdateEmployee(request);

            return Ok(request.Id);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            await employeeService.DeleteEmployeeById(id);

            return Ok(id);
        }
    }
}
