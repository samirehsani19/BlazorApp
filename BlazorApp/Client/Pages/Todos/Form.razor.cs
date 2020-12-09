using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Pages.Todos
{
    public partial class Form
    {
        [Parameter] public Todo todo { get; set; }
        [Parameter] public string ButtonText { get; set; } = "Save";
        [Parameter] public EventCallback OnValidSubmit { get; set; }
    }
}
