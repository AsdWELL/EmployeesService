using EmployeeService.Domain.Dto.Employee;

namespace EmployeeService.Application.Validators
{
    public static class EmployeeRequestsValidator
    {
        private static void ValidateEmployeeNamePart(string value, string fieldName)
        {
            Ensure.StringNotEmpty(value, fieldName);
            Ensure.ContainsOnlyLetters(value, fieldName);
        }

        private static void ValidateEmployeeName(string employeeName) => ValidateEmployeeNamePart(employeeName, "Employee Name");
        private static void ValidateEmployeeSurname(string employeeSurname) => ValidateEmployeeNamePart(employeeSurname, "Employee Surname");

        private static void ValidateEmployeePhone(string employeePhone)
        {
            Ensure.PhoneNumber(employeePhone, "Employee Phone");
        }

        public static void ValidateAddRequest(this AddEmployeeRequest request)
        {
            ValidateEmployeeName(request.Name);
            ValidateEmployeeSurname(request.Surname);

            ValidateEmployeePhone(request.Phone);

            request.Passport.ValidateAddRequest();
        }

        public static void ValidateUpdateRequest(this UpdateEmployeeRequest request)
        {
            if (request.Name != null)
                ValidateEmployeeName(request.Name);

            if (request.Surname != null)
                ValidateEmployeeSurname(request.Surname);

            if (request.Phone != null)
                ValidateEmployeePhone(request.Phone);

            if (request.Passport != null)
                request.Passport.ValidateAddRequest();
        }
    }
}
