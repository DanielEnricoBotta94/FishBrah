using ImageMagick;

namespace FishBrah.Extensions;

public static class FileExtensions
{
    public static async Task WriteToFile(this MagickImage image, string name)
    {
        var fileInfo = new FileInfo($"{name}.jpg");
        await image.WriteAsync(fileInfo.FullName);
    }
}