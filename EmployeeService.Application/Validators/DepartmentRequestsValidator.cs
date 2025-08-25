using EmployeeService.Application.Dto.Department;

namespace EmployeeService.Application.Validators
{
    public static class DepartmentRequestsValidator
    {
        private static void ValidateDepartmentName(string departmentName)
        {
            Ensure.StringNotEmpty(departmentName, "Department Name");
        }

        private static void ValidateDepartmentPhone(string departmentPhone)
        {
            Ensure.PhoneNumber(departmentPhone, "Department Phone");
        }

        public static void ValidateAddRequest(this AddDepartmentRequest request)
        {
            ValidateDepartmentName(request.Name);

            ValidateDepartmentPhone(request.Phone);
        }

        public static void ValidateUpdateRequest(this UpdateDepartmentRequest request)
        {
            if (request.Name != null)
                ValidateDepartmentName(request.Name);

            if (request.Phone != null)
                ValidateDepartmentPhone(request.Phone);
        }
    }
}
