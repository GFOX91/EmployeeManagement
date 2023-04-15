using EmployeeManagement.Data;
using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Data;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDbContext _context;

    public DepartmentRepository(AppDbContext context)
    {
        _context = context;
    }
    public Department Get(int id)
    {
        return _context.Departments
            .FirstOrDefault(d => d.Id == id);
    }

    public IEnumerable<Department> List()
    {
        return _context.Departments;
    }
}

