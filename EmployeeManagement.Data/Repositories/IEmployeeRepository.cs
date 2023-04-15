using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Data;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> List();
    Task<IEnumerable<Employee>> Search(string name, Gender? gender);
    Task<Employee> Get(int id);
    Task<Employee> Get(string email);
    Task<Employee> Add(Employee employee);
    Task<Employee> Update(Employee employee);
    Task<Employee> Delete(int id);
}

