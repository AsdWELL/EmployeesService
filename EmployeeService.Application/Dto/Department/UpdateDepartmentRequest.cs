namespace EmployeeService.Application.Dto.Department
{
    /// <summary>
    /// Модель запроса на обновление информации об отделе
    /// </summary>
    public class UpdateDepartmentRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Телефонный номер
        /// </summary>
        public string? Phone { get; set; }
    }
}
