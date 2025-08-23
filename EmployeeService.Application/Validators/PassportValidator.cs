using EmployeeService.Application.Dto.Passport;

namespace EmployeeService.Application.Validators
{
    public static class PassportValidator
    {
        private static void ValidatePassportType(string passportType)
        {
            string fieldName = "Passport Type";

            Ensure.StringNotEmpty(passportType, fieldName);
            Ensure.MustNotContainDigits(passportType, fieldName);
        }
        
        private static void ValidatePassportNumber(string passportNumber)
        {
            string fieldName = "Passport Number";

            Ensure.StringNotEmpty(passportNumber, fieldName);
            Ensure.HasLength(passportNumber, fieldName, 10);
            Ensure.ContainsOnlyDigits(passportNumber, fieldName);
        }
        
        public static void ValidateAddRequest(this AddPassportRequest passport)
        {
            ValidatePassportType(passport.Type);
            
            ValidatePassportNumber(passport.Number);
        }
    }
}
