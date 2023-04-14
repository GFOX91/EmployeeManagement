using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Data;

public interface IDepartmentRepository
{
    IEnumerable<Department> List();
    Department Get(int id);
}

