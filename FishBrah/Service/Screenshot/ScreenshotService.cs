using System.Drawing;
using System.Drawing.Imaging;
using FishBrah.Extensions;
using FishBrah.Helpers;
using FishBrah.Service.Cancellation;
using FishBrah.Service.Random;
using ImageMagick;
using ImageMagick.Configuration;

namespace FishBrah.Service.Screenshot;

#pragma warning disable CA1416
public class ScreenshotService : IScreenshotService
{
    private const int DifferenceTreshold = 20_000;
    
    private readonly ICancellationTokenService _cancellationTokenService;
    private readonly IRandomService _randomService;
    private FileInfo? _current;
    private FileInfo? _previous;

    public ScreenshotService(ICancellationTokenService cancellationTokenService, IRandomService randomService)
    {
        _cancellationTokenService = cancellationTokenService;
        _randomService = randomService;
    }

    public async Task CaptureAsync()
    {
        var delay = _randomService.Generate(500, 1000);
        await Task.Delay(delay, _cancellationTokenService.Get(this).Token);
        using var bitmap = GetBitmap();
        SetCurrentAndPrevious(bitmap);
    }

    private static Bitmap GetBitmap()
    {
        var bitmap = new Bitmap(1366, 768);
        using var g = Graphics.FromImage(bitmap);
        var size = new Size(1366, 768);
        g.CopyFromScreen(0, 0, 0, 0, size, CopyPixelOperation.SourceCopy);
        return bitmap;
    }
    
    private void SetCurrentAndPrevious(Bitmap bitmap)
    {
        _previous?.Delete();
        _previous = _current;
        _current = new FileInfo($"{_randomService.Generate(int.MaxValue)}.jpg");
        bitmap.Save(_current.Name, ImageFormat.Png);
    }

    public (uint x, uint y)[] GetDifferencesAsync()
    {
        var differences = new List<(uint, uint)>();

        if (_previous is null || _current is null)
            return Array.Empty<(uint x, uint y)>();
        
        var previous = ImageHelper.PrepareImage(_previous.FullName);
        var current = ImageHelper.PrepareImage(_current.FullName);

        using var previousPixels = previous.GetPixels();
        using var currentPixels = current.GetPixels();
        for (var i = 0; i < previous.Width - 1; i++)
        {
            for (var j = 0; j < current.Height - 1; j++)
            {
                var difference = (ushort)Math.Abs(previousPixels[i, j]!.ToColor()!.B - currentPixels[i, j]!.ToColor()!.B);
                if (difference < DifferenceTreshold) 
                    continue;
                
                var tuple = ((uint)i, (uint)j);
                differences.Add(tuple);
                //SetDiff(
            }
        }

        return differences.ToArray();
    }

    private void SetDiff(IPixelCollection<ushort> pixelCollection, int i1, int i2, ushort diff)

    {
        var pixel = pixelCollection[i1, i2]!;
        pixel.SetChannel(0, diff);
        pixel.SetChannel(1, diff);
        pixel.SetChannel(2, diff);
        pixelCollection.SetPixel(pixel);
    }
}
#pragma warning restore CA1416
