using System;

namespace Pic.Albums.Data.Dto
{
    public record AlbumDto
    {
        public string Name { get; }

        public string Description { get; }

        public string Owner { get; }

        public DateTime CreationTime { get; }

        public AlbumDto(string name, string description, string owner, DateTime creationTime) =>
            (Name, Description, Owner, CreationTime) = (name, description, owner, creationTime);
    }
}