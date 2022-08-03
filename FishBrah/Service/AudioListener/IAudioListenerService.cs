using FishBrah.Delegates;

namespace FishBrah.Service.AudioListener;

public interface IAudioListenerService
{
    public event FishDelegates.FishDetect? OnFishDetect;
    Task Listen();
    void StopListening();
}