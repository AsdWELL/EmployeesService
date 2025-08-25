using EmployeeService.Application.Dto.Department;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Application.Mappers
{
    public static class DepartmentMapper
    {
        public static Department MapToDomain(this AddDepartmentRequest request)
        {
            return new Department
            {
                Name = request.Name,
                Phone = request.Phone
            };
        }

        public static Department MapToDomain(this UpdateDepartmentRequest request)
        {
            return new Department
            {
                Id = request.Id,
                Name = request.Name,
                Phone = request.Phone
            };
        }

        public static DepartmentResponse MapToDto(this Department department)
        {
            return new DepartmentResponse
            {
                Id = department.Id,
                Name = department.Name,
                Phone = department.Phone
            };
        }

        public static List<DepartmentResponse> MapToResponseList(this List<Department> departments)
        {
            return departments.Select(MapToDto).ToList();
        }
    }
}
