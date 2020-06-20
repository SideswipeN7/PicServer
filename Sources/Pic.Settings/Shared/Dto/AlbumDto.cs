using System.Collections.Generic;

namespace Pic.Settings.Shared.Dto
{
    public class AlbumDto
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Path { get; set; }
        public List<string> Groups { get; set; }
        public bool RequireAuthorization { get; set; }
    }
}