using System.Reflection;

namespace Pic.Settings.Client.Providers
{
    public class VersionProvider
    {
        public string Version => Assembly.GetEntryAssembly().GetName().Version.ToString();
    }
}