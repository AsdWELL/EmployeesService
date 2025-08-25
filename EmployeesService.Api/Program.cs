using EmployeeService.DataAccess.Extensions;

namespace EmployeeService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddDatabase(builder.Configuration)
                .AddRepositories();

            var app = builder.Build();

            app.Run();
        }
    }
}
