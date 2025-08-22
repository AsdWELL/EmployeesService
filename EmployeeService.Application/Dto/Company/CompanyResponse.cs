namespace EmployeeService.Application.Dto.Company
{
    /// <summary>
    /// Модель получения информации о компании
    /// </summary>
    public class CompanyResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

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
