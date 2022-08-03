namespace FishBrah.Service.CancellationToken;

public class CancellationTokenService : ICancellationTokenService
{
    private readonly CancellationTokenSource _cancellationTokenSource;

    public CancellationTokenService(CancellationTokenSource cancellationTokenSource)
    {
        _cancellationTokenSource = cancellationTokenSource;
    }

    public System.Threading.CancellationToken Token => _cancellationTokenSource.Token;
}