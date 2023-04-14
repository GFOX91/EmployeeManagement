using EmployeeManagement.Api.Data;

namespace EmployeeManagement.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
    }
}

