using FishBrah.Controllers;
using FishBrah.Handler;
using FishBrah.Service.AudioListener;
using FishBrah.Service.Cancellation;
using FishBrah.Service.Keyboard;
using FishBrah.Service.Random;
using FishBrah.Service.Screenshot;

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, _) => cts.Cancel();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICancellationTokenService, CancellationTokenService>(_ => new CancellationTokenService(cts));
builder.Services.AddSingleton<IRandomService, RandomService>();
builder.Services.AddSingleton<IAudioListenerService, AudioListenerService>();
builder.Services.AddSingleton<IScreenshotService, ScreenshotService>();
builder.Services.AddSingleton<IKeyboardService, KeyboardService>();
builder.Services.AddSingleton<IFishHandler, FishHandler>();

await builder
    .Build()
    .MapFishController()
    .RunAsync(cts.Token);