using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pic.Data.Models;
using Pic.Logic.PhotoAlbums.Queries;
using Pic.Logic.Photos.Commands;
using Pic.Service.Controllers.Models.PhotoAlbums;

namespace Pic.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly ILogger<PhotoController> logger;
        private readonly IMediator mediator;

        public PhotoController(ILogger<PhotoController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpPost("add")]
        public Task Add(PhotoAlbumModifyRequest addPhotoAlbum)
        {
            return mediator.Send(new CreatePhotoAlbumCommand(addPhotoAlbum.Title));
        }

        [HttpPut("{id}")]
        public Task Add(int id, PhotoAlbumModifyRequest addPhotoAlbum)
        {
            return mediator.Send(new UpdatePhotoAlbumTitleCommand(id, addPhotoAlbum.Title));
        }

        [HttpDelete("{id}")]
        public Task MarkAsDeleted(int id)
        {
            return mediator.Send(new MarkPhotoAlbumAsDeletedCommand(id));
        }

        [HttpDelete("force-delete")]
        public Task MarkAsDeleted()
        {
            return mediator.Send(new DeletePhotoAlbumsCommand());
        }

        [HttpGet]
        public Task<IEnumerable<AlbumInfo>> Get()
        {
            return mediator.Send(new GetPhotoAlbumsInfoQuery());
        }
    }
}
