using System.Reflection.Metadata.Ecma335;
using FishBrah.Helpers;
using ImageMagick;

namespace FishBrah.Models;

public record Rectangle(int Width, int Height);

public class FishImage : IDisposable
{
    private readonly MagickImage _image;

    public readonly Rectangle Original;
    public readonly Rectangle Scaled;

    private const int ScaleWidth = 200;
    public FishImage(string path)
    {
        _image = new MagickImage(path);
        Original = new Rectangle(_image.Width, _image.Height);
        var height = ScaleWidth * Original.Height / Original.Width;
        Scaled = new Rectangle(ScaleWidth, height);
        _image.Scale(Scaled.Width, Scaled.Height);
    }

    public IPixelCollection<ushort> GetPixels()
    {
        return _image.GetPixels();
    }

    public void Dispose()
    {
        _image?.Dispose();
    }

    ~FishImage()
    {
        _image?.Dispose();
    }

}
