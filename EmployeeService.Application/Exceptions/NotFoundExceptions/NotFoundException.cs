namespace EmployeeService.Application.Exceptions.NotFoundExceptions
{
    public abstract class NotFoundException(string message) : Exception(message);
}