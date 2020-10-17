using Pic.Database.Data.Entities;
using Pic.Pictures.Entities;

namespace Pic.Albums.Data.Entities
{
    public class AlbumsPictures : BaseEntity
    {
        public int PictureId { get; set; }

        public int AlbumId { get; set; }

        public int OrderId { get; set; }

        public Album Album { get; set; }

        public Picture Picture { get; set; }
    }
}