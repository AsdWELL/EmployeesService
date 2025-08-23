namespace EmployeeService.Application.Dto.Passport
{
    /// <summary>
    /// Модель получения информации о паспорте
    /// </summary>
    public class PassportResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

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
