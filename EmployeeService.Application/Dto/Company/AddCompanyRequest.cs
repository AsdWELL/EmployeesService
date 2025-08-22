namespace EmployeeService.Application.Dto.Company
{
    /// <summary>
    /// Модель запроса на добавление компании
    /// </summary>
    public class AddCompanyRequest
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; }
    }
}
