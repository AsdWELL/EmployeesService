using EmployeeService.Application.Dto.Department;
using EmployeeService.Application.Exceptions.NotFoundExceptions;
using EmployeeService.Application.Interfaces.Services;
using EmployeeService.Application.Mappers;
using EmployeeService.Application.Validators;
using EmployeeService.Application.Interfaces.Repositories;

namespace EmployeeService.Application.Services
{
    public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
    {
        private async Task ThrowIfDepartmentNotExists(int id)
        {
            if (!await departmentRepository.IsDepartmentExists(id))
                throw new DepartmentNotFoundException(id);
        }
        
        public async Task<int> AddDepartment(AddDepartmentRequest request)
        {
            request.ValidateAddRequest();
            
            return await departmentRepository.AddDepartment(request.MapToDomain());
        }

        public async Task<List<DepartmentResponse>> GetAllDepartments()
        {
            var companies = await departmentRepository.GetAllDepartments();

            return companies.MapToResponseList();
        }

        public async Task<DepartmentResponse> GetDepartmentById(int id)
        {
            var department = await departmentRepository.GetDepartmentById(id)
                ?? throw new DepartmentNotFoundException(id);

            return department.MapToDto();
        }

        public async Task UpdateDepartment(UpdateDepartmentRequest request)
        {
            await ThrowIfDepartmentNotExists(request.Id);

            request.ValidateUpdateRequest();
            
            await departmentRepository.UpdateDepartment(request.MapToDomain());
        }

        public async Task DeleteDepartmentById(int id)
        {
            await ThrowIfDepartmentNotExists(id);

            await departmentRepository.DeleteDepartmentById(id);
        }
    }
}
