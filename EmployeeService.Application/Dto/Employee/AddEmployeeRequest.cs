using EmployeeService.Application.Dto.Passport;

namespace EmployeeService.Application.Dto.Employee
{
    /// <summary>
    /// Модель запроса на добавление сотрудника
    /// </summary>
    public class AddEmployeeRequest
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Телефонный номер
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Идентификатор компании
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Паспорт
        /// </summary>
        public AddPassportRequest Passport { get; set; }

        /// <summary>
        /// Идентификатор отдела
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
