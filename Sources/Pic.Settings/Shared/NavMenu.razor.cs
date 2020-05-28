using Blazorise.Sidebar;

namespace Pic.Settings.Shared
{
    public partial class NavMenu
    {
        Sidebar sidebar { get; set; }
        public void ToggleSidebar()
        {
            sidebar.Toggle();
        }
    }
}