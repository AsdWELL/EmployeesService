using EmployeeService.Application.Exceptions;
using System.Text.RegularExpressions;

namespace EmployeeService.Application.Validators
{
    /// <summary>
    /// Класс, содержащий базовые методы для валидации
    /// </summary>
    public static partial class Ensure
    {
        [GeneratedRegex(@"^(8|\+7)\d{10}$")]
        private static partial Regex PhoneNumberRegex();
        
        /// <summary>
        /// Проверяет, что строка не null, не пустая и не состоит из пробелов
        /// </summary>
        /// <exception cref="InvalidFieldValueException"></exception>
        public static void StringNotEmpty(string? value, string fieldName)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new InvalidFieldValueException($"Поле '{fieldName}' не может быть пустым");
        }

        /// <summary>
        /// Проверяет, что строка соответстует формату телефонных номеров +7 или 8 и следом 10 цифр
        /// </summary>
        /// <exception cref="InvalidFieldValueException"></exception>
        public static void PhoneNumber(string? value, string fieldName)
        {
            StringNotEmpty(value, fieldName);

            if (!PhoneNumberRegex().IsMatch(value!))
                throw new InvalidFieldValueException($"Неверный формат номера у поля '{fieldName}'");
        }

        /// <summary>
        /// Проверяет, что строка содержит только цифры
        /// </summary>
        /// <exception cref="InvalidFieldValueException"></exception>
        public static void ContainsOnlyDigits(string? value, string fieldName)
        {
            StringNotEmpty(value, fieldName);

            if (!value!.All(char.IsDigit))
                throw new InvalidFieldValueException($"Поле '{fieldName}' должно состоять только из цифр");
        }

        /// <summary>
        /// Проверяет, что строка содержит только буквы
        /// </summary>
        /// <exception cref="InvalidFieldValueException"></exception>
        public static void MustNotContainDigits(string? value, string fieldName)
        {
            StringNotEmpty(value, fieldName);

            if (value!.Any(char.IsDigit))
                throw new InvalidFieldValueException($"Поле '{fieldName}' не может содержать цифр");
        }

        /// <summary>
        /// Проверяет, что длина строки равна указанной длине
        /// </summary>
        /// <exception cref="InvalidFieldValueException"></exception>
        public static void HasLength(string? value, string fieldName, int length)
        {
            StringNotEmpty(value, fieldName);

            if (value!.Length != length)
                throw new InvalidFieldValueException($"Поле '{fieldName}' должно иметь {length} символов");
        }
    }
}
