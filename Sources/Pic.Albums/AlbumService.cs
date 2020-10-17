using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pic.Albums.Data.Entities;
using Pic.Database.Abstraction;
using Pic.Database.Interfaces;

namespace Pic.Albums
{
    public class AlbumService : GenericService<Album>
    {
        public AlbumService(IContext context) : base(context)
        { }

        public async Task<Album> GetAlbum(int id) => await Get(x => x.Id == id);

        public async Task<IEnumerable<Album>> GetAlbums() => await GetAll();

        public async Task<int> CreateAlbum(string albumName, string albumDescription)
        {
            var newAlbum = new Album
            {
                Name = albumName,
                Description = albumDescription,
            };

            return (await Add(newAlbum)).First();
        }

        public async Task UpdateAlbum(int albumId, string albumName, string albumDescription)
        {
            Album album = await Get(x => x.Id == albumId);

            if (album is null)
            {
                throw new NullReferenceException($"{typeof(Album).Name} with ID: {albumId} does not exists!");
            }


            album.Name = albumName;
            album.Description = albumDescription;

            await context.SaveChangesAsync();
        }
    }
}