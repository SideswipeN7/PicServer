namespace Pic.Service.Controllers;

[ApiController]
[Route("api/photo-albums")]
public class PhotoAlbumsController : ControllerBase
{
    private readonly IMediator mediator;

    public PhotoAlbumsController(IMediator mediator) => this.mediator = mediator;

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

    [HttpPatch("restore/{id}")]
    public Task Restore(int id)
    {
        return mediator.Send(new RestorePhotoAlbumsCommand(new[] { id }));
    }

    [HttpPatch("restore")]
    public Task Restore(IEnumerable<int> ids)
    {
        return mediator.Send(new RestorePhotoAlbumsCommand(ids));
    }

    [HttpDelete("{id}")]
    public Task MarkAsDeleted(int id)
    {
        return mediator.Send(new MarkPhotoAlbumsAsDeletedCommand(new[] { id }));
    }

    [HttpDelete]
    public Task MarkAsDeleted(IEnumerable<int> ids)
    {
        return mediator.Send(new MarkPhotoAlbumsAsDeletedCommand(ids));
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
