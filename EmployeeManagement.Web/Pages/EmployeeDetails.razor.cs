using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Web.Pages;

public partial class EmployeeDetails
{
    public Employee Employee { get; set; }

    protected string Coordinates { get; set; }

    protected string ButtonText { get; set; } = "Hide Footer";
    protected string CssClass { get; set; }

    [Inject]
    public IEmployeeService EmployeeService { get; set; }

    [Parameter]
    public string Id { get; set; }

    protected async  override Task OnInitializedAsync()
    {
        Employee = await EmployeeService.Get(int.Parse(Id));
    }

    protected void HideFooter_Click()
    {
        if (ButtonText == "Hide Footer")
        {
            ButtonText = "Show Footer";
            CssClass = "d-none";
        }
        else
        {
            CssClass = null;
            ButtonText = "Hide Footer";
        }
    }
}

