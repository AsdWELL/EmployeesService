namespace EmployeeService.Application.Dto.Company
{
    /// <summary>
    /// Модель запроса на обновление информации о компании
    /// </summary>
    public class UpdateCompanyRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string? Name { get; set; }
    }
}
