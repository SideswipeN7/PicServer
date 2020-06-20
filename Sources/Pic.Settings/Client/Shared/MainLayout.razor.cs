using Microsoft.AspNetCore.Components;
using Pic.Settings.Client.Providers;

namespace Pic.Settings.Client.Shared
{
    public partial class MainLayout
    {
        [Inject]
        private AppNameProvider AppNameProvider { get; set; }

        private bool IsOpened { get; set; } = true;

        private void ToggleMenu() => IsOpened = !IsOpened;
    }
}