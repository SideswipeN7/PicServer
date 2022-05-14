using Pic.Core.Domain.Photos.Commands;

namespace Pic.Core.Logic.Photos.Queries;

public class GetPhotoQueryHandler : IRequestHandler<GetPhotoByIdQuery, byte[]>
{
    private readonly ILogger<GetPhotoQueryHandler> logger;
    private readonly IPathGenerationService pathGenerationService;
    private readonly IPhotoRepository photoRepository;

    public GetPhotoQueryHandler(ILogger<GetPhotoQueryHandler> logger, IPathGenerationService pathGenerationService, IPhotoRepository photoRepository)
    {
        this.logger = logger;
        this.pathGenerationService = pathGenerationService;
        this.photoRepository = photoRepository;
    }

    public async Task<byte[]> Handle(GetPhotoByIdQuery request, CancellationToken cancellationToken)
    {
        using var scope = logger.BeginScope(new Dictionary<string, object>
        {
            ["Action"] = nameof(GetPhotoByIdQuery),
            ["PhotoId"] = request.PhotoId,
        });

        logger.LogInformation("Searching for Photo with ID: {PhotoId}", request.PhotoId);
        var photoPathParts = await photoRepository.GetPathParts(request.PhotoId, cancellationToken);

        if (photoPathParts is null)
        {
            logger.LogError("Could not found Photo with ID: {PhotoId}", request.PhotoId);

            throw new DomainException("Could not found selected Photo.");
        }

        var path = pathGenerationService.GeneratePath(photoPathParts.PhotoAlbumDirectory, photoPathParts.PhotoFileName);

        if (!File.Exists(path))
        {
            logger.LogError("Could not found file for Photo with ID: {PhotoId}. Path: \"{PhotoPath}\".", request.PhotoId, path);

            return Array.Empty<byte>();
        }

        logger.LogInformation("Getting bytes for Photo with ID: {PhotoId}. Path: \"{PhotoPath}\".", request.PhotoId, path);

        return await File.ReadAllBytesAsync(path, cancellationToken);
    }
}
