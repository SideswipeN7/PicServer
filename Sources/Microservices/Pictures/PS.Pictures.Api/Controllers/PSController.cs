using Microsoft.AspNetCore.Mvc;

namespace PS.Pictures.Api.Controllers;

public abstract class PSController : ControllerBase
{        
    protected string GetUserId() => this.User.Claims.First(i => i.Type == "UserId").Value;
}
