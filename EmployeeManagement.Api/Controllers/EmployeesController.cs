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
}

