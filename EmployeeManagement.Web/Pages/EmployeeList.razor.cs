using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages;

public partial class EmployeeList
{
    [Inject]
    public IEmployeeService EmployeeService { get; set; }

    public IEnumerable<Employee> Employees { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Employees = await EmployeeService.List();
    }
}

