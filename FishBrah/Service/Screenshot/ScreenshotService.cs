using CSCore.CoreAudioAPI;
using FishBrah.Service.Cancellation;
using FishBrah.Service.Random;

namespace FishBrah.Service.Screenshot;

public class ScreenshotService : IScreenshotService
{
    private readonly ICancellationTokenService _cancellationTokenService;
    private readonly IRandomService _randomService; 

    public ScreenshotService(ICancellationTokenService cancellationTokenService, IRandomService randomService)
    {
        _cancellationTokenService = cancellationTokenService;
        _randomService = randomService;
    }

    public async Task CaptureAsync()
    {
        var delay = _randomService.Generate(300);
        await Task.Delay(delay, _cancellationTokenService.Get(this).Token);
    }

    public (uint x, uint y)[] GetDifferences()
    {
        throw new NotImplementedException();
    }
}