using System.Runtime.InteropServices;
using FishBrah.Service.Random;
using WindowsInput;

namespace FishBrah.Service.Keyboard;

#pragma warning disable CA1416
public class KeyboardService : IKeyboardService
{
    private readonly IRandomService _randomService;

    public KeyboardService(IRandomService randomService)
    {
        _randomService = randomService;
    }

    public async Task PressOne()
    {
        var delay = _randomService.Generate(500, 1000);
        await Task.Delay(delay);
        new InputSimulator().Keyboard
            .KeyPress(VirtualKeyCode.VK_1)
            .KeyUp(VirtualKeyCode.VK_1);
    }

    public void ClickAndLoot(int x, int y)
    {
        new InputSimulator().Keyboard
            .KeyDown(VirtualKeyCode.SHIFT)
            .Mouse
            .MoveMouseTo(x,y)
            .RightButtonClick()
            .Keyboard
            .KeyUp(VirtualKeyCode.SHIFT);
    }
}
#pragma warning restore CA1416
