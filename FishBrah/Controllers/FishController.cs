using FishBrah.Handler;
using FishBrah.Service.AudioListener;
using FishBrah.Service.Keyboard;

namespace FishBrah.Controllers;

public static class PopupControllerExt
{
    public static WebApplication MapFishController(this WebApplication app)
    {
        app.MapGet("/start", async (
            HttpRequest request,
            IAudioListenerService audioListenerService,
            IFishHandler fishHandler) =>
        {
            await Task.Delay(5000);
            Console.WriteLine("started");
            await fishHandler.FishAsync();
            _ = Task.Run(audioListenerService.Listen, request.HttpContext.RequestAborted);
            return Results.Ok();
        });
        
        app.MapGet("/stop", (
            IAudioListenerService audioListenerService,
            IFishHandler fishHandler) =>
        {
            Console.WriteLine("stopped");
            audioListenerService.StopListening();
            fishHandler.Cancel();
            return Results.Ok();
        });
        return app;
    }
}