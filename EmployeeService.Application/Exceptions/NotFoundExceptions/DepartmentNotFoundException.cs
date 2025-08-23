namespace EmployeeService.Application.Exceptions.NotFoundExceptions
{
    public class DepartmentNotFoundException(int departmentId) : NotFoundException($"Отдел с id {departmentId} не найден");
}