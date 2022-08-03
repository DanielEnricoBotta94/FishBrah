using CSCore.CoreAudioAPI;
using FishBrah.Delegates;
using FishBrah.Service.Cancellation;

namespace FishBrah.Service.AudioListener;

public class AudioListenerService : IAudioListenerService
{
    private const double FishThreshold = 0.99;
    private const int ListenInterval = 100;
    
    private readonly ICancellationTokenService _cancellationTokenService;

    public event FishDelegates.FishDetect? OnFishDetect;
    
    public AudioListenerService(ICancellationTokenService cancellationTokenService)
    {
        _cancellationTokenService = cancellationTokenService;
    }

    public async Task Listen()
    {
        using var enumerator = new MMDeviceEnumerator();
        var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
        using var meter = AudioMeterInformation.FromDevice(device);
        var tokenSource = _cancellationTokenService.Get(this);
        while (!tokenSource?.IsCancellationRequested ?? false)
        {
            if (meter.PeakValue > FishThreshold)
            {
                OnFishDetect?.Invoke();
            }
            await Task.Delay(ListenInterval, tokenSource.Token);
        }
    }


    public void StopListening()
    {
        _cancellationTokenService.Get(this)?.Cancel();
    }
}