
using CSCore.CoreAudioAPI;
using FishBrah.Extensions;
using FishBrah.Helpers;
using ImageMagick;


while (true)
{
    using var enumerator = new MMDeviceEnumerator();
    var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
    using var meter = AudioMeterInformation.FromDevice(device);
    Console.WriteLine(meter.PeakValue);
    if (meter.PeakValue > 0.99)
        return;
    await Task.Delay(20);
}


var max = 0;
void SetDiff(IPixelCollection<ushort> pixelCollection, int i1, int i2, ushort diff)
{
    if (diff < 20_000)
        diff = 0;
    var pixel = pixelCollection[i1, i2]!;
    pixel.SetChannel(0, diff);
    pixel.SetChannel(1, diff);
    pixel.SetChannel(2, diff);
    pixelCollection.SetPixel(pixel);
}

var first = ImageHelper.PrepareImage("Assets/TestComparison/1.jpg");
var second = ImageHelper.PrepareImage("Assets/TestComparison/2.jpg");
var blue = ImageHelper.PrepareImage("Assets/TestComparison/2.jpg");

using var firstPixels = first.GetPixels();
using var secondPixels = second.GetPixels();
using var bluePixels = blue.GetPixels();
for (var i = 0; i < first.Width - 1; i++)
{
    for (var j = 0; j < second.Height - 1; j++)
    {
        try
        {
            var b = (ushort)Math.Abs(firstPixels[i, j]!.ToColor()!.B - secondPixels[i, j]!.ToColor()!.B);
            SetDiff(bluePixels, i, j, b);
        }
        catch (Exception ex)
        {
    
        }
    }
}

await blue.WriteToFile(nameof(blue));
