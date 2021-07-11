namespace Pic.Data.Entities
{
    public class Album : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string MiniaturePicture { get; set; }
    }
}