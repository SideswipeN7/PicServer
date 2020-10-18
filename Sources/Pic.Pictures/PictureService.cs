using System;
using Pic.Database.Abstraction;
using Pic.Database.Interfaces;
using Pic.Pictures.Entities;

namespace Pic.Pictures
{
    public class PictureService : GenericService<Picture>
    {
        public PictureService(IContext context) : base(context)
        { }


    }
}