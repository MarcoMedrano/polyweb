using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PolyWeb.Client;
using Radzen;
using Microsoft.JSInterop;
using System.Globalization;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<DownloadInfoService>();
builder.Services.AddLocalization();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredLocalStorageAsSingleton();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var host = builder.Build();
var js = host.Services.GetRequiredService<IJSRuntime>();
var localStorage = host.Services.GetRequiredService<ISyncLocalStorageService>();
var culture = localStorage.GetItem<string>("culture") ?? await js.InvokeAsync<string>("eval", "navigator.language || navigator.userLanguage") ?? "en";
culture = culture.Contains("-") ? culture.Split("-")[0] : culture;
Console.WriteLine("CULTURE " + culture);

if (!string.IsNullOrEmpty(culture))
{
    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(culture);
    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(culture);
}

await host.RunAsync();