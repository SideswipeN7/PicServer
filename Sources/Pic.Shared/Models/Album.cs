using System.Collections.Generic;

namespace Pic.Shared.Models
{
    public class Album
    {
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Path { get; set; }
        public List<string>? UserGroups { get; set; }
        public bool RequireAuthorization { get; set; }
    }
}