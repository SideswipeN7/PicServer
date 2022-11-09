using MediatR;
using Microsoft.AspNetCore.Mvc;
using PS.Storage.Application.Commands.Delete;
using PS.Storage.Application.Commands.Upload;
using PS.Storage.Application.Queries;

namespace PS.Storage.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly IMediator mediator;

    public FileController(IMediator mediator) => this.mediator = mediator;

    [HttpPost]
    public Task<Guid> Upload(IFormFile file)
    {
        using var ms = new MemoryStream();
        file.CopyTo(ms);
        var fileBytes = ms.ToArray();

        return mediator.Send(new UploadFileCommand(file.FileName, fileBytes));
    }

    [HttpDelete("{fileName}")]
    public Task<bool> Delete(string fileName)
    {
        return mediator.Send(new DeleteFileCommand(fileName));
    }

    [HttpGet("{fileName}")]
    public Task<byte[]> Download(string fileName)
    {
        return mediator.Send(new ReadFileQuery(fileName));
    }
}
