using EmployeeManagement.Web.Services;

namespace EmployeeManagement.Web.Extensions;

public static class WebApllicationBuilderExtensions
{
    public static void AddHttpClients(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7282/api/");
        });
    }
}

