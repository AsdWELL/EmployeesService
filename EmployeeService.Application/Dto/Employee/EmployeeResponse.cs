using EmployeeService.Application.Dto;
using EmployeeService.Application.Dto.Company;
using EmployeeService.Application.Dto.Department;

namespace EmployeeService.Domain.Dto.Employee
{
    /// <summary>
    /// Модель получения информации о сотруднике
    /// </summary>
    public class EmployeeResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

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
        /// Компания
        /// </summary>
        public CompanyResponse Company { get; set; }

        /// <summary>
        /// Паспорт
        /// </summary>
        public PassportDto Passport { get; set; }

        /// <summary>
        /// Отдел
        /// </summary>
        public DepartmentResponse Department { get; set; }
    }
}
