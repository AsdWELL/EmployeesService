using EmployeeService.Application.Dto.Employee;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Application.Mappers
{
    public static class EmployeeMapper
    {
        public static Employee MapToDomain(this AddEmployeeRequest request, int passportId)
        {
            return new Employee
            {
                Name = request.Name,
                Surname = request.Surname,
                Phone = request.Phone,
                CompanyId = request.CompanyId,
                PassportId = passportId,
                DepartmentId = request.DepartmentId
            };
        }

        public static Employee MapToDomain(this UpdateEmployeeRequest request, int? passportId)
        {
            var employee = new Employee
            {
                Name = request.Name,
                Surname = request.Surname,
                Phone = request.Phone
            };

            if (request.CompanyId != null)
                employee.CompanyId = request.CompanyId.Value;

            if (passportId != null)
                employee.PassportId = passportId.Value;

            if (request.DepartmentId != null)
                employee.DepartmentId = request.DepartmentId.Value;

            return employee;
        }

        public static EmployeeResponse MapToDto(
            this Employee employee,
            Company company,
            Passport passport,
            Department department)
        {
            return new EmployeeResponse
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                Phone = employee.Phone,
                Company = company.MapToDto(),
                Passport = passport.MapToDto(),
                Department = department.MapToDto()
            };
        }
    }
}
