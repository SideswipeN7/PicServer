using MediatR;
using Microsoft.AspNetCore.Mvc;
using PS.Pictures.Api.Controllers.Pictures.DTOs;
using PS.Pictures.Application.Pictures.Models;
using PS.Pictures.Application.Pictures.Queries;

namespace PS.Pictures.Api.Controllers.Pictures;

[ApiController]
[Route("[controller]")]
public class PicturesController : PSController
{
    private readonly IMediator mediator;

    public PicturesController(IMediator mediator) => this.mediator = mediator;

    [HttpGet("{uid:guid}")]
    public Task<PictureVm> GetUserImage(Guid uid)
    {
        return mediator.Send(new GetUserPictureQuery(uid, GetUserId()));
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreatePictureRequest request)
    {
        var uid = Guid.NewGuid();

        await mediator.Send(request.AsCommand(uid, GetUserId()));

        return CreatedAtAction(nameof(Create), new { Uid = uid });
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateAsDuplicate(CreatePictureRequest request)
    {
        var uid = Guid.NewGuid();

        await mediator.Send(request.AsCommand(uid, GetUserId()));

        return CreatedAtAction(nameof(Create), new { Uid = uid });
    }

    [HttpPut("{uid:guid}")]
    public async Task<ActionResult> Update(Guid uid, EditPictureRequest request)
    {
        await mediator.Send(request.AsCommand(uid, GetUserId()));

        return NoContent();
    }
}
