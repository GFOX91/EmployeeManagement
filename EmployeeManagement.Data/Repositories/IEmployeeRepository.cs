using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Data;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> List();
    Task<Employee> Get(int id);
    Task<Employee> Add(Employee employee);
    Task<Employee> Update(Employee employee);
    Task Delete(int id);
}

