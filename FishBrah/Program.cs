using FishBrah;
using FishBrah.Controllers;
using FishBrah.Service.CancellationToken;

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, _) => cts.Cancel();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICancellationTokenService, CancellationTokenService>(_ =>
    new CancellationTokenService(cts));
builder.Services.AddSingleton<IAudioListenerService, AudioListenerService>();
builder.Services.AddSingleton<IScreenshotService, ScreenshotService>();

await builder
    .Build()
    .MapFishController()
    .RunAsync(cts.Token);