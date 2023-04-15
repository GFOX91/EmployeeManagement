using EmployeeManagement.Api.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetEmployees()
    {
        try
        {
            return Ok(await _employeeRepository.List());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult> GetEmployee(int id)
    {
        try
        {
            var employee = await _employeeRepository.Get(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }        
    }

    [HttpPost]
    public async Task<ActionResult> CreateEmployee(Employee employee)
    {
        try
        {
            if (employee == null) 
                return BadRequest();

            var existingEmployee = await _employeeRepository.Get(employee.Email);

            if (existingEmployee != null)
            {
                ModelState.AddModelError("email", "Employee email already in use");
                return BadRequest(ModelState);
            }

            var createdEmployee = await _employeeRepository.Add(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateEmployee(int id, Employee employee)
    {
        try
        {
            if (id != employee.Id)
                return BadRequest("Employee Id mismatch");

            var employeeToUpdate = await _employeeRepository.Get(employee.Email);

            if (employeeToUpdate == null)
            {
                return NotFound($"Employee with Id:{id} not found");
            }

            await _employeeRepository.Update(employee);

            return AcceptedAtAction(nameof(GetEmployee), new { id = employee.Id });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Employee>> UpdateEmployee(int id)
    {
        try
        {
            var employeeToDelete = await _employeeRepository.Get(id);

            if (employeeToDelete == null)
            {
                return NotFound($"Employee with Id:{id} not found");
            }

            return await _employeeRepository.Delete(id);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{search}")]
    public async Task<ActionResult> Search(string name, Gender? gender)
    {
        try
        {
            var employees = await _employeeRepository.Search(name, gender);

            if (employees.Any())
            {
                return Ok(employees);
            }

            return NotFound("No matching employees found");
        }
        catch (Exception)
        {

            throw;
        }
    }
}

