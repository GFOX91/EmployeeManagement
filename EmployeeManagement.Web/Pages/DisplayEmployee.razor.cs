using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages;

public partial class DisplayEmployee
{
    [Parameter]
    public Employee Employee { get; set; }

    [Parameter]
    public bool ShowFooter { get; set; }
}

