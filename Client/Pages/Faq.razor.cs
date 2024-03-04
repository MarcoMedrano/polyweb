using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Radzen;
using Microsoft.AspNetCore.Components;

namespace PolyWeb.Client.Pages;

public partial class Faq
{
    [Inject]
    protected IJSRuntime JSRuntime { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    protected TooltipService TooltipService { get; set; }

    [Inject]
    protected ContextMenuService ContextMenuService { get; set; }

    [Inject]
    protected NotificationService NotificationService { get; set; }

    bool isEdge;
    string usageVideoLink;

    protected override async Task OnInitializedAsync()
    {
        var userAgent = await JSRuntime.InvokeAsync<string>("eval", " window.navigator.userAgent");
        isEdge = userAgent.Contains("Edg");

        if(isEdge) usageVideoLink = "https://www.youtube.com/embed/f3SAODZjHpY?si=_YYZu8b6gWZ2MDFn";
        else usageVideoLink = "https://www.youtube.com/embed/vFYG66x8zCY?si=FVXLTc8INnE1PIAQ";
    }
}