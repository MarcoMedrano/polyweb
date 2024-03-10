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

    [Inject] DownloadInfoService DownloadInfoService { get; set; }

    [Parameter]
    [SupplyParameterFromQuery]
    public string Navigate { get; set; }

    DownloadInfo x86Info;
    DownloadInfo x64Info;

    string currentVersion = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(Navigate)) NavigationManager.NavigateTo($"/{Navigate}");

        x86Info = await DownloadInfoService.GetX86DownloadInfoAsync();
        x64Info = await DownloadInfoService.GetX64DownloadInfoAsync();

        currentVersion = x86Info.Version;
    }

    private void DownloadWindowsX86() => Download(x86Info.Url);
    private void DownloadWindowsX64() => Download(x64Info.Url);

    private void Download(string url)
    {
        NavigationManager.NavigateTo(url);
        NavigationManager.NavigateTo("/faq");
    }
}
