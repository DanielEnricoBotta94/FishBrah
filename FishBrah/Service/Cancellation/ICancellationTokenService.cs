namespace FishBrah.Service.Cancellation;

public interface ICancellationTokenService
{
    public CancellationTokenSource Get<T>(T reference);
}