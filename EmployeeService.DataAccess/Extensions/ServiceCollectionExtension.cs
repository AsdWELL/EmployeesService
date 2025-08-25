using DbUp;
using EmployeeService.DataAccess.Interfaces.Repositories;
using EmployeeService.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;
using System.Reflection;

namespace EmployeeService.DataAccess.Extensions
{
    public static class ServiceCollectionExtension
    {
        private const string DatabaseConnectionStringName = "EmployeesDatabase";

        /// <summary>
        /// Выполняет миграцию БД и настройку её подключения
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DatabaseConnectionStringName);

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Отсутствует строка подключения для БД");

            services
                .AddScoped<IDbConnection>(_ => new NpgsqlConnection(connectionString))
                .MigrateDatabase(connectionString);

            return services;
        }

        /// <summary>
        /// Выполняет миграцию бд
        /// </summary>
        /// <returns></returns>
        private static IServiceCollection MigrateDatabase(this IServiceCollection services, string connectionString)
        {
            EnsureDatabase.For.PostgresqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .WithTransaction()
                .WithVariablesDisabled()
                .LogToConsole()
                .Build();

            if (upgrader.IsUpgradeRequired())
            {
                upgrader.PerformUpgrade();
            }

            return services;
        }

        /// <summary>
        /// Добавляет репозитории
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<ICompanyRepository, CompanyRepository>()
                .AddScoped<IPassportRepository, PassportRepository>()
                .AddScoped<IDepartmentRepository, DepartmentRepository>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
