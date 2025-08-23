namespace EmployeeService.Application.Exceptions
{
    public class InvalidFieldValueException(string message) : Exception($"Ошибка: {message}");
}
