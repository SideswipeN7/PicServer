using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pic.Albums.Data.Dto;
using Pic.Albums.Data.Entities;
using Pic.Database.Abstraction;
using Pic.Database.Interfaces;

namespace Pic.Albums
{
    public class AlbumPictureService : GenericService<AlbumPicture>
    {
        public AlbumPictureService(IContext context) : base(context)
        { }

        public async Task<IEnumerable<AlbumPicture>> GetAlbumPictures(int albumId) =>
            await GetAllAlbumPictures(albumId).Where(x => !x.Deleted).ToListAsync();

        public async Task<IEnumerable<AlbumPicture>> GetAlbumPicturesDeleted(int albumId) =>
            await GetAllAlbumPictures(albumId).Where(x => x.Deleted).ToListAsync();

        public async Task ReorderPictures(AlbumPictureDto[] changeOrderList, int albumId)
        {
            IQueryable<AlbumPicture> albumsPictures = GetAllAlbumPictures(albumId).Where(x => !x.Deleted);
            foreach (var changeOrderData in changeOrderList)
            {
                AlbumPicture albumPicture = albumsPictures.FirstOrDefault(x => x.Id == changeOrderData.PictureId);
                if (albumPicture is null)
                {
                    throw new ArgumentException("Picture does not exists!");
                }

                albumPicture.OrderId = changeOrderData.OrderId;
            }

            await context.SaveChangesAsync();
        }


        private IQueryable<AlbumPicture> GetAllAlbumPictures(int albumId) =>
            context.GetDbSet<AlbumPicture>().Where(x => x.AlbumId == albumId);
    }
}