using ImageMagick;

namespace FishBrah.Helpers;

public static class ImageHelper
{
    public static MagickImage PrepareImage(string path)
    {
        var image = new MagickImage(path);
        const int width = 200;
        var height = width * image.Height / image.Width;
        image.Scale(width, height);
        return image;
    }
}