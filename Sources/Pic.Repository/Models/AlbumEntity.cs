using Pic.Shared.Abstraction;
using System.Collections.Generic;

namespace Pic.Repository.Models
{
    public class AlbumEntity : DbEntity
    {
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Path { get; set; }
        public List<string>? Groups { get; set; }
        public bool RequireAuthorization { get; set; }

        public override string? GetKey => Title;
    }
}