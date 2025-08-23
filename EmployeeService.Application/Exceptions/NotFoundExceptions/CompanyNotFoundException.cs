namespace EmployeeService.Application.Exceptions.NotFoundExceptions
{
    public class CompanyNotFoundException(int companyId) : NotFoundException($"Компания с id {companyId} не найдена");
}
