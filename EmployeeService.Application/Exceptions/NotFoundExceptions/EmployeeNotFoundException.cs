namespace EmployeeService.Application.Exceptions.NotFoundExceptions
{
    public class EmployeeNotFoundException(int employeeId) : NotFoundException($"Сотрудник с id {employeeId} не найден");
}
