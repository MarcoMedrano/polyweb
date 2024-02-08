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

    private void DownloadWindowsx86() => NavigationManager.NavigateTo("https://polytranslator.s3.amazonaws.com/windows/x86/0.0.0.1/Poly.msi", forceLoad: true);
    private void DownloadWindowsx64() => NavigationManager.NavigateTo("https://polytranslator.s3.amazonaws.com/windows/x64/0.0.0.1/Poly.msi", forceLoad: true);
}
