namespace Pic.Service.Areas.Photos;

[ApiController]
[Route("api/photos")]
public class PhotosController : ControllerBase
{
    private readonly IMediator mediator;

    public PhotosController(IMediator mediator) => this.mediator = mediator;

    [HttpPost("add")]
    public Task Add(AddPhoto addPhotoDto)
    {
        var command = Mapper.Map<AddPhotoCommand>(addPhotoDto);

        return mediator.Send(command);
    }

    [HttpGet("by-filename/{name}")]
    public async Task<IActionResult> Get(string name)
    {
        var command = Mapper.Map<GetPhotoQuery>(name);

        var fileBytes = await mediator.Send(command);
        if (fileBytes is null)
        {
            return NotFound();
        }

        return File(fileBytes, "image/png", name);
    }
}
