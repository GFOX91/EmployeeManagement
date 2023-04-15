using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Web.Pages;

public partial class EmployeeDetails
{
    public Employee Employee { get; set; }

    protected string Coordinates { get; set; }

    [Inject]
    public IEmployeeService EmployeeService { get; set; }

    [Parameter]
    public string Id { get; set; }

    protected async  override Task OnInitializedAsync()
    {
        Employee = await EmployeeService.Get(int.Parse(Id));
    }

    protected void Mouse_Move(MouseEventArgs e)
    {
        Coordinates = $"X = {e.ClientX} Y = {e.ClientY}";
    }
}

