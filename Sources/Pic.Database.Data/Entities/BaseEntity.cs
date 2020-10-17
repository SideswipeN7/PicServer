using System;

namespace Pic.Database.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public bool Deleted { get; set; }
    }
}