using EmployeeService.Application.Dto.Department;
using EmployeeService.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesService.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DepartmentController(IDepartmentService departmentService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentRequest request)
        {
            return Ok(await departmentService.AddDepartment(request));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            return Ok(await departmentService.GetDepartmentById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            return Ok(await departmentService.GetAllDepartments());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentRequest request)
        {
            await departmentService.UpdateDepartment(request);

            return Ok(request.Id);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartmentById([FromRoute] int id)
        {
            await departmentService.DeleteDepartmentById(id);

            return Ok(id);
        }
    }
}
