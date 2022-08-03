using System.Reflection.Metadata.Ecma335;
using FishBrah.Helpers;
using ImageMagick;

namespace FishBrah.Models;

public record Rectangle(int Width, int Height);

public class FishImage : IDisposable
{
    private readonly MagickImage _image;

    public Rectangle Original;
    public Rectangle Scaled;

    public FishImage(string path)
    {
        _image = new MagickImage(path);
        Original = new Rectangle(_image.Width, _image.Height);
        this.PrepareImage();
    }

    public void Scale(Rectangle rect)
    {
        Scaled = rect;
        _image.Scale(rect.Width, rect.Height);
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
