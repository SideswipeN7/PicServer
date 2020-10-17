using Pic.Database.Data.Entities;

namespace Pic.Pictures.Entities
{
    public class Picture : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}