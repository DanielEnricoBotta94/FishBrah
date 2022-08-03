namespace FishBrah.Service.Screenshot;

public interface IScreenshotService
{
    Task CaptureAsync();
    (int x, int y)[] GetDifferencesAsync();
}