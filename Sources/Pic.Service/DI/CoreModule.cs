namespace Pic.Service.DI
{
    internal static class CoreModule
    {
        internal static void Register(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreatePhotoAlbumCommand).Assembly);
        }
    }
}
