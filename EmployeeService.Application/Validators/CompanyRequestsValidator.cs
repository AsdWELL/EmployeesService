using EmployeeService.Application.Dto.Company;

namespace EmployeeService.Application.Validators
{
    public static class CompanyRequestsValidator
    {
        private static void ValidateCompanyName(string companyName)
        {
            Ensure.StringNotEmpty(companyName, "Company Name");
        }

        private static void ValidateCompanyInn(string companyInn)
        {
            string fieldName = "Company Inn";
            
            Ensure.HasLength(companyInn, fieldName, 10);
            Ensure.ContainsOnlyDigits(companyInn, fieldName);
        }
        
        public static void ValidateAddRequest(this AddCompanyRequest request)
        {
            ValidateCompanyName(request.Name);
            
            ValidateCompanyInn(request.Inn);
        }

        public static void ValidateUpdateRequest(this UpdateCompanyRequest request)
        {
            if (request.Name != null)
                ValidateCompanyName(request.Name);
        }
    }
}
