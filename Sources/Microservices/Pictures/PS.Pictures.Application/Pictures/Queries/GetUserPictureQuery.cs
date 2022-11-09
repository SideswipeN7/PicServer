using PS.Pictures.Application.Pictures.Models;
using PS.Shared.Application.CQRS.Queries;

namespace PS.Pictures.Application.Pictures.Queries;

public record GetUserPictureQuery(Guid Uid, string UserId) : IQuery<PictureVm>;
