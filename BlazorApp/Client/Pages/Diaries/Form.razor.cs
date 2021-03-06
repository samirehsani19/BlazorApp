﻿using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Pages.Diaries
{
    public partial class Form
    {
        [Parameter] public BlazorApp.Shared.Models.Diary diary { get; set; }
        [Parameter] public string ButtonText { get; set; } = "Save";
        [Parameter] public EventCallback OnValidSubmit { get; set; }
    }
}
