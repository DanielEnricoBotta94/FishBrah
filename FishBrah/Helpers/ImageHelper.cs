using FishBrah.Models;

namespace FishBrah.Helpers;

public static class ImageHelper
{
    public static (int, int) GetAdjustedDifference(FishImage image, int i, int j)
    {
        var adjustedX = i * image.Original.Width / image.Scaled.Width;
        var adjustedY = j * image.Original.Height / image.Scaled.Height;
            
        return (adjustedX, adjustedY);
    }
}