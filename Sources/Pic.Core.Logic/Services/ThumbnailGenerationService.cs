using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Pic.Core.Infrastructure.Interfaces.Services;

internal class ThumbnailGenerationService : IThumbnailGenerationService
{
    public byte[] Generate(byte[] image)
    {

    }

    public byte[] MakeThumbnail(byte[] bytes, int thumbWidth, int thumbHeight)
    {
        using var ms = new MemoryStream(bytes);
        var thumb = new Bitmap(thumbWidth, thumbHeight);
        using (var bmp = Image.FromStream(ms))
        using (var graphics = Graphics.FromImage(thumb))
        {
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.DrawImage(bmp, 0, 0, 100, 100);
        }

        using (var stream = new MemoryStream())
        {
            thumb.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            return stream.ToArray();
        }
    }
}
