namespace EmployeeService.Application.Dto
{
    /// <summary>
    /// Модель запроса на довабление паспорта
    /// </summary>
    public class PassportDto
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
