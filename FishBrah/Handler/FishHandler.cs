using FishBrah.Service.AudioListener;
using FishBrah.Service.Keyboard;
using FishBrah.Service.Screenshot;

namespace FishBrah.Handler;

public class FishHandler : IFishHandler
{
    private readonly IAudioListenerService _audioListenerService;
    private readonly IKeyboardService _keyboardService;
    private readonly IScreenshotService _screenshotService;

    public FishHandler(IKeyboardService keyboardService, IScreenshotService screenshotService,
        IAudioListenerService audioListenerService)
    {
        _keyboardService = keyboardService;
        _screenshotService = screenshotService;
        _audioListenerService = audioListenerService;
    }

    public async Task FishAsync()
    {
        _audioListenerService.OnFishDetect += Reel;
        await _screenshotService.CaptureAsync();
        await _keyboardService.PressOne();
        await _screenshotService.CaptureAsync();
    }

    public void Reel()
    {
        var coordinates = _screenshotService.GetDifferencesAsync();
        for (var i = 0; i < coordinates.Length; i++) _keyboardService.ClickAndLoot(coordinates[i].x, coordinates[i].y);
        //_audioListenerService.OnFishDetect -= Reel;
    }

    public void Cancel()
    {
        _audioListenerService.OnFishDetect -= Reel;
    }
}