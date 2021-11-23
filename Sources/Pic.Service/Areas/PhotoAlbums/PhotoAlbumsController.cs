namespace Pic.Service.Areas.PhotoAlbums;

[ApiController]
[Route("api/photo-albums")]
public class PhotoAlbumsController : ControllerBase
{
    private readonly IMediator mediator;

    public PhotoAlbumsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("add")]
    public Task Add(CreatePhotoAlbumRequest createPhotoAlbumRequest)
    {
        var command = Mapper.Map<CreatePhotoAlbumCommand>(createPhotoAlbumRequest);

        return mediator.Send(command);
    }

    [HttpPut("{id}")]
    public Task Edit(int id, UpdatePhotoAlbumRequest updatePhotoAlbumRequest)
    {
        var command = Mapper.MapWithId<UpdatePhotoAlbumRequest>(updatePhotoAlbumRequest, id);

        return mediator.Send(command);
    }

    [HttpPatch("restore/{id}")]
    public Task Restore(int id)
    {
        var command = Mapper.Map<RestorePhotoAlbumsCommand>(id);

        return mediator.Send(command);
    }

    [HttpPatch("restore")]
    public Task Restore(IEnumerable<int> ids)
    {
        var command = Mapper.Map<RestorePhotoAlbumsCommand>(ids);

        return mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public Task MarkAsDeleted(int id)
    {
        var command = Mapper.Map<MarkPhotoAlbumsAsDeletedCommand>(id);

        return mediator.Send(command);
    }

    [HttpDelete]
    public Task MarkAsDeleted(IEnumerable<int> ids)
    {
        var command = Mapper.Map<MarkPhotoAlbumsAsDeletedCommand>(ids);

        return mediator.Send(command);
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

    [HttpGet("{id}")]
    public Task<AlbumInfo> GetById(int id)
    {
        var command = Mapper.Map<GetSinglePhotoAlbumInfoQuery>(id);

        return mediator.Send(command);
    }
}
