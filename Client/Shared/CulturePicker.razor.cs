using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Blazored.LocalStorage;

namespace PolyWeb.Client.Shared
{
    public partial class CulturePicker
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

        [Inject] ILocalStorageService localStorage {get;set;}

        protected string culture;

        protected override void OnInitialized()
        {
            culture = CultureInfo.CurrentCulture.Name;
        }

        protected async Task ChangeCulture()
        {
            await localStorage.SetItemAsync("culture", culture);
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }
    }
}