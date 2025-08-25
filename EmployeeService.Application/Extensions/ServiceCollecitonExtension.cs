using EmployeeService.Application.Interfaces.Services;
using EmployeeService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeService.Application.Extensions
{
    public static class ServiceCollecitonExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ICompanyService, CompanyService>()
                .AddScoped<IDepartmentService, DepartmentService>()
                .AddScoped<IEmployeeService, Services.EmployeeService>();
        }
    }
}
