using EmployeeService.Application.Dto.Employee;
using EmployeeService.Application.Exceptions.NotFoundExceptions;
using EmployeeService.Application.Interfaces.Services;
using EmployeeService.Application.Mappers;
using EmployeeService.Application.Validators;
using EmployeeService.Application.Interfaces.Repositories;
using System.Transactions;

namespace EmployeeService.Application.Services
{
    public class EmployeeService(
        IEmployeeRepository employeeRepository,
        IPassportRepository passportRepository) : IEmployeeService
    {
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
            return await employeeRepository.GetAllEmployees();
        }

        public async Task<EmployeeResponse> GetEmployeeById(int id)
        {
            var employee = await employeeRepository.GetEmployeeDetailsById(id)
                ?? throw new EmployeeNotFoundException(id);

            return employee;
        }

        public async Task<List<EmployeeResponse>> GetEmployeesByCompanyId(int companyId)
        {
            return await employeeRepository.GetEmployeesByCompanyId(companyId);
        }

        public async Task<List<EmployeeResponse>> GetEmployeesByCompanyIdAndDepartmentId(int companyId, int departmentId)
        {
            return await employeeRepository.GetEmployeesByCompanyIdAndDepartmentId(companyId, departmentId);
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
