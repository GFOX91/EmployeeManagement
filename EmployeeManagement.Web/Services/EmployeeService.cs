using EmployeeManagement.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace EmployeeManagement.Web.Services;

public class EmployeeService : IEmployeeService
{
    private readonly HttpClient _httpClient;

    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<Employee>> List()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Employee[]>("employees");
        }
        catch (Exception ex)
        {
            throw;
        }
        
    }

    public async Task<Employee> Get(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"employees/{id}");
        }
        catch (Exception ex)
        {
            throw;
        }

    }
}

