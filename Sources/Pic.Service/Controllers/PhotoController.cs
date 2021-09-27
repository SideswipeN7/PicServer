using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pic.Logic.Photos.Commands;
using Pic.Logic.Photos.Queries;
using Pic.Service.Controllers.Models;

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
        public Task Add(AddPhoto addPhotoDto)
        {
            return mediator.Send(new AddPhotoCommand(addPhotoDto.photoData, addPhotoDto.photoName));
        }

        [HttpGet("by-filename/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var fileBytes = await mediator.Send(new GetPhotoQuery(name));
            if(fileBytes is null)
            {
                return NotFound();
            }

            return File(fileBytes, "image/png", name);
        }
    }
}
