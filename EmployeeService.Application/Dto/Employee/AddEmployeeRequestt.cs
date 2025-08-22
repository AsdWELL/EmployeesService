using EmployeeService.Application.Dto;

namespace EmployeeService.Domain.Dto.Employee
{
    /// <summary>
    /// Модель запроса на добавление сотрудника
    /// </summary>
    public class AddEmployeeRequestt
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
        /// Паспорта
        /// </summary>
        public PassportDto Passport { get; set; }

        /// <summary>
        /// Идентификатор отдела
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
