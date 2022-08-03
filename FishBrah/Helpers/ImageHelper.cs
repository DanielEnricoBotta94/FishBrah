using FishBrah.Models;
using ImageMagick;
using Rectangle = System.Drawing.Rectangle;

namespace FishBrah.Helpers;

public static class ImageHelper
{
    private const int Width = 200;
    
    public static void PrepareImage(this FishImage image)
    {
        var height = Width * image.Original.Height / image.Original.Width;
        image.Scale(new Models.Rectangle(Width, height));
    }

    public static (int, int) GetAdjustedDifference(FishImage image, int i, int j)
    {
        var adjustedX = i * image.Original.Width / image.Scaled.Width;
        var adjustedY = j * image.Original.Height / image.Scaled.Height;
            
        return (adjustedX, adjustedY);
    }
}