namespace EmployeeService.Domain.Dto.Department
{
    /// <summary>
    /// Модель запроса на добавление отдела
    /// </summary>
    public class AddDepartmentRequest
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Телефонный номер
        /// </summary>
        public string Phone { get; set; }
    }
}
