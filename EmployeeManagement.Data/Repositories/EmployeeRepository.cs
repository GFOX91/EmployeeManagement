using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Data;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Employee> Add(Employee employee)
    {
       var result = await _context.Employees.AddAsync(employee);
        _context.SaveChanges();
        return result.Entity;
    }

    public async Task<Employee> Delete(int id)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(x => x.Id == id);

        if (employee != null)
        {
            _context.Employees .Remove(employee);
            await _context.SaveChangesAsync();
        }

        return employee;
    }

    public async Task<Employee> Get(int id)
    {
        return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Employee> Get(string email)
    {
        return await _context.Employees.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<IEnumerable<Employee>> List()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
    {
        IQueryable<Employee> query = _context.Employees;

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(e => e.FirstName.Contains(name)
                                || e.LastName.Contains(name));
        }

        if (gender.HasValue)
        {
            query = query.Where(e => e.Gender == gender.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<Employee> Update(Employee employee)
    {
        var result = await _context.Employees
            .FirstOrDefaultAsync(x => x.Id == employee.Id);

        if (result != null)
        {
            result.FirstName = employee.FirstName;
            result.LastName = employee.LastName;
            result.Email = employee.Email;
            result.DateOfBirth = employee.DateOfBirth;
            result.Gender = employee.Gender;
            result.DepartmentId = employee.DepartmentId;
            result.PhotoPath = employee.PhotoPath;

            await _context.SaveChangesAsync();

            return result;
        }

        return null;
    }
}

