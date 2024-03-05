using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace PolyWeb.Client.Shared
{
    public partial class MainLayout
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

        private bool sidebarExpanded = false;
        string lemonTreeStyle = string.Empty;

        void SidebarToggleClick()
        {
            sidebarExpanded = !sidebarExpanded;
        }

        protected override async Task OnInitializedAsync()
        {
            var width = await JSRuntime.InvokeAsync<int>("eval", "window.innerWidth");
            Console.WriteLine("WIDTH " +width);
            if(width > 1000) lemonTreeStyle = "background-image: url('images/lemon-tree.png'); background-repeat: no-repeat; background-position: bottom left;";
        }
    }
}
