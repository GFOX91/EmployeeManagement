using EmployeeManagement.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

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
}

