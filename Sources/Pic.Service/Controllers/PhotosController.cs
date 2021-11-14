namespace Pic.Service.Controllers;

[ApiController]
[Route("api/photos")]
public class PhotosController : ControllerBase
{
    private readonly IMediator mediator;

    public PhotosController(IMediator mediator) => this.mediator = mediator;

    [HttpPost("add")]
    public Task Add(AddPhoto addPhotoDto)
    {
        return mediator.Send(new AddPhotoCommand(addPhotoDto.PhotoData, addPhotoDto.PhotoName));
    }

    [HttpGet("by-filename/{name}")]
    public async Task<IActionResult> Get(string name)
    {
        var fileBytes = await mediator.Send(new GetPhotoQuery(name));
        if (fileBytes is null)
        {
            return NotFound();
        }

        return File(fileBytes, "image/png", name);
    }
}
