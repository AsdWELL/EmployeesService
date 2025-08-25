using EmployeeService.Application.Dto.Passport;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Application.Mappers
{
    public static class PassportMapper
    {
        public static Passport MapToDomain(this AddPassportRequest request)
        {
            return new Passport
            {
                Number = request.Number,
                Type = request.Type
            };
        }

        public static PassportResponse MapToDto(this Passport passport)
        {
            return new PassportResponse
            {
                Id = passport.Id,
                Number = passport.Number,
                Type = passport.Type
            };
        }
    }
}
