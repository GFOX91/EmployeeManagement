using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services;

/// <summary>
/// The service used to retrieve all things related to the employee 
/// </summary>
public interface IEmployeeService
{
    Task<IEnumerable<Employee>> List();
}

