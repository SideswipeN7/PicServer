using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pic.Server.DTO
{
    public class AlbumDto
    {
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        [MinLength(1)]
        public List<string> Groups { get; set; }
        [Required]
        public bool RequireAuthorization { get; set; }
    }
}