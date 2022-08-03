namespace FishBrah.Service.Keyboard;

public interface IKeyboardService
{
    Task PressOne();
    Task ClickAndLoot(int x, int y);
}