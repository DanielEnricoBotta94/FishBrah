namespace FishBrah.Controllers;

public static class PopupControllerExt
{
    public static WebApplication MapFishController(this WebApplication app)
    {
        app.MapGet("/start", () =>
        {
            Console.WriteLine("Registered");
            //start app
            return Results.Ok();
        });
        app.MapGet("/stop", () =>
        {
            Console.WriteLine("stopped");
            //stop app
            return Results.Ok();
        });
        return app;
    }
}