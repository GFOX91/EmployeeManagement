using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages;

public partial class EmployeeDetails
{
    public Employee Employee { get; set; } = new Employee();

    [Inject]
    public IEmployeeService EmployeeService { get; set; }

    [Parameter]
    public string Id { get; set; }

    protected async  override Task OnInitializedAsync()
    {
        Employee = await EmployeeService.Get(int.Parse(Id));
    }
}

