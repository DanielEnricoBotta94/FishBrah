namespace FishBrah.Handler;

public interface IFishHandler
{
    Task FishAsync();
    void Reel();
    void Cancel();
}