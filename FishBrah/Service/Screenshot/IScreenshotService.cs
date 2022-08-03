namespace FishBrah.Service.Screenshot;

public interface IScreenshotService
{
    Task CaptureAsync();
    (uint x, uint y)[] GetDifferencesAsync();
}