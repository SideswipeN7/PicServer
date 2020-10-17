using System.Collections.Generic;
using Pic.Database.Data.Entities;

namespace Pic.Albums.Data.Entities
{
    public class Album : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<AlbumsPictures> Pictures { get; set; }
    }
}