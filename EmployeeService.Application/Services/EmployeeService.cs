using EmployeeService.Application.Dto.Employee;
using EmployeeService.Application.Exceptions.NotFoundExceptions;
using EmployeeService.Application.Interfaces.Services;
using EmployeeService.Application.Mappers;
using EmployeeService.Application.Validators;
using EmployeeService.DataAccess.Interfaces.Repositories;
using EmployeeService.Domain.Entities;
using System.Transactions;

namespace EmployeeService.Application.Services
{
    public class EmployeeService(
        IEmployeeRepository employeeRepository,
        ICompanyRepository companyRepository,
        IDepartmentRepository departmentRepository,
        IPassportRepository passportRepository) : IEmployeeService
    {
        private async Task<EmployeeResponse> BuildEmployeeResponse(Employee employee) 
        {
            var company = await companyRepository.GetCompanyById(employee.CompanyId);
            var passport = await passportRepository.GetPassportById(employee.PassportId);
            var department = await departmentRepository.GetDepartmentById(employee.DepartmentId);

            return employee.MapToDto(company, passport, department);
        }

        private async IAsyncEnumerable<EmployeeResponse> BuildEmployeeResponseList(List<Employee> employees)
        {
            foreach (var employee in employees)
                yield return await BuildEmployeeResponse(employee);
        }

        public async Task<int> AddEmployee(AddEmployeeRequest request)
        {
            request.ValidateAddRequest();

            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var passportId = await passportRepository.AddPassport(request.Passport.MapToDomain());

                var employeeId = await employeeRepository.AddEmployee(request.MapToDomain(passportId));

                transactionScope.Complete();

                return employeeId;
            }
        }

        public async Task<List<EmployeeResponse>> GetAllEmployees()
        {
            var employees = await employeeRepository.GetAllEmployees();

            return await BuildEmployeeResponseList(employees).ToListAsync();
        }

        public async Task<EmployeeResponse> GetEmployeeById(int id)
        {
            var employee = await employeeRepository.GetEmployeeById(id)
                ?? throw new EmployeeNotFoundException(id);

            return await BuildEmployeeResponse(employee);
        }

        public async Task<List<EmployeeResponse>> GetEmployeesByCompanyId(int companyId)
        {
            var employees = await employeeRepository.GetEmployeesByCompanyId(companyId);

            return await BuildEmployeeResponseList(employees).ToListAsync();
        }

        public async Task<List<EmployeeResponse>> GetEmployeesByCompanyIdAndDepartmentId(int companyId, int departmentId)
        {
            var employees = await employeeRepository.GetEmployeesByCompanyIdAndDepartmentId(companyId, departmentId);

            return await BuildEmployeeResponseList(employees).ToListAsync();
        }

        public async Task UpdateEmployee(UpdateEmployeeRequest request)
        {
            request.ValidateUpdateRequest();

            var oldEmployee = await employeeRepository.GetEmployeeById(request.Id)
                ?? throw new EmployeeNotFoundException(request.Id);

            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                int? passportId = null;

                if (request.Passport != null)
                {
                    passportId = await passportRepository.AddPassport(request.Passport.MapToDomain());

                    await passportRepository.DeletePassportById(oldEmployee.PassportId);
                }

                await employeeRepository.UpdateEmployee(request.MapToDomain(passportId));

                transactionScope.Complete();
            }
        }

        public async Task DeleteEmployeeById(int id)
        {
            var oldEmployee = await employeeRepository.GetEmployeeById(id)
                ?? throw new EmployeeNotFoundException(id);

            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await employeeRepository.DeleteEmployeeById(id);

                await passportRepository.DeletePassportById(oldEmployee.PassportId);
                
                transactionScope.Complete();
            }
        }
    }
}
