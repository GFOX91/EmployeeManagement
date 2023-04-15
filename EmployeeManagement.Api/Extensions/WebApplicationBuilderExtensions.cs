using EmployeeManagement.Api.Data;

namespace EmployeeManagement.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
    }
}

