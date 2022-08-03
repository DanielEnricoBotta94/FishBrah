using FishBrah.Handler;
using FishBrah.Service.AudioListener;
using FishBrah.Service.Screenshot;
using Microsoft.AspNetCore.Mvc;

namespace FishBrah.Controllers;

public static class PopupControllerExt
{
    public static WebApplication MapFishController(this WebApplication app)
    {
        app.MapGet("/start",async  (
            HttpRequest request, 
            IAudioListenerService audioListenerService, 
            IFishHandler fishHandler) =>
        {
            Console.WriteLine("started");
            await fishHandler.FishAsync();
            _ = Task.Run(audioListenerService.Listen, request.HttpContext.RequestAborted);
            return Results.Ok();
        });
        app.MapGet("/stop", (
            IAudioListenerService audioListenerService) =>
        {
            Console.WriteLine("stopped");
            audioListenerService.StopListening();
            return Results.Ok();
        });
        return app;
    }
}