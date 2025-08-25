using Microsoft.OpenApi.Models;

namespace EmployeesService.Api.Extentions
{
    public static class ServiceCollecitonExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddEndpointsApiExplorer()
                            .AddSwaggerGen(options =>
                            {
                                options.SwaggerDoc("Employees", new OpenApiInfo
                                {
                                    Version = "v1",
                                    Title = "Сотрудники",
                                    Description = "Тестовое задание"
                                });
                            });
        }
    }
}
