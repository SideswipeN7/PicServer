namespace Pic.Albums.Data.Dto
{
    public record AlbumPictureDto
    {
        public int PictureId { get; }
        public int OrderId { get; }

        public AlbumPictureDto(int pictureId, int orderId) =>
            (PictureId, OrderId) = (pictureId, orderId);
    }
}