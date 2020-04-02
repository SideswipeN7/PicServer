using LiteDB;

namespace Pic.Repository.Models
{
    public class EntitiesMapping
    {
        public EntitiesMapping()
        {
            var mapper = BsonMapper.Global;

            mapper.Entity<AlbumEntity>()
                  .Id(x => x.Title);

            mapper.Entity<GroupEntity>()
                  .Id(x => x.Name);

            mapper.Entity<UserEntity>()
                  .Id(x => x.Username);
        }
    }
}