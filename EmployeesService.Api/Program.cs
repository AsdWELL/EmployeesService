using EmployeeService.Application.Extensions;
using EmployeeService.DataAccess.Extensions;
using EmployeesService.Api.Extentions;
using EmployeesService.Api.Filters;

namespace EmployeeService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwagger();

            builder.Services
                .AddDatabase(builder.Configuration)
                .AddRepositories()
                .AddServices();

            builder.Services.AddControllers(
                options => options.Filters.Add<ExceptionFilter>());

            var app = builder.Build();

            app.UseSwagger()
               .UseSwaggerUI(options =>
               {
                   options.SwaggerEndpoint("/swagger/Employees/swagger.json", "Employees WebApi");
                   options.RoutePrefix = string.Empty;
               });

            app.MapControllers();

            app.Run();
        }
    }
}
