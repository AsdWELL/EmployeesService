using EmployeeService.Domain.Entities;

namespace EmployeeService.Application.Interfaces.Repositories
{
    public interface IPassportRepository
    {
        Task<int> AddPassport(Passport passport);

        Task<Passport?> GetPassportById(int id);

        Task DeletePassportById(int id);
    }
}
