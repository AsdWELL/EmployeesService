namespace EmployeeService.Application.Dto.Passport
{
    /// <summary>
    /// Модель запроса на добавление паспорта
    /// </summary>
    public class AddPassportRequest
    {
        /// <summary>
        /// Тип
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }
    }
}
