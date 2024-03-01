using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace PolyWeb.Client.Pages;

public partial class Index
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

    [Parameter] [SupplyParameterFromQuery]
    public string Navigate { get; set; }

    protected override void OnInitialized()
    {
        if(!string.IsNullOrEmpty(Navigate)) NavigationManager.NavigateTo($"/{Navigate}");
    }

    private void DownloadWindowsx86()
    {
        NavigationManager.NavigateTo("https://polytranslator.s3.amazonaws.com/windows/x86/0.0.0.3/Poly.msi");
        NavigationManager.NavigateTo("/faq");
    }

    private void DownloadWindowsx64()
    {
        NavigationManager.NavigateTo("https://polytranslator.s3.amazonaws.com/windows/x64/0.0.0.3/Poly.msi");
        NavigationManager.NavigateTo("/faq");
    }
}
