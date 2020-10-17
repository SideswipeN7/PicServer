using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pic.Albums.Data.Entities;
using Pic.Database.Abstraction;
using Pic.Database.Interfaces;

namespace Pic.Albums
{
    public class AlbumsPicturesService : GenericService<AlbumsPictures>
    {
        public AlbumsPicturesService(IContext context) : base(context)
        { }
    }
}