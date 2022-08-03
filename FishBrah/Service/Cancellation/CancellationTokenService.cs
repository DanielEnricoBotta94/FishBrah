using Microsoft.Extensions.Caching.Memory;

namespace FishBrah.Service.Cancellation;

public class CancellationTokenService : ICancellationTokenService
{
    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly MemoryCache _cache = new(new MemoryCacheOptions());

    public CancellationTokenService(CancellationTokenSource cancellationTokenSource)
    {
        _cancellationTokenSource = cancellationTokenSource;
    }

    public CancellationTokenSource Get<T>(T reference)
    {
        if (_cache.TryGetValue<CancellationTokenSource>(typeof(T), out var tokenSource))
            return tokenSource;
        tokenSource = CancellationTokenSource.CreateLinkedTokenSource(_cancellationTokenSource.Token);
        return _cache.Set(typeof(T), tokenSource);
    }
}