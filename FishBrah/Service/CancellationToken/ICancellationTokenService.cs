namespace FishBrah.Service.CancellationToken;

public interface ICancellationTokenService
{
    public System.Threading.CancellationToken Token { get; }
}