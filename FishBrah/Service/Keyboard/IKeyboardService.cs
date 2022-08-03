namespace FishBrah.Service.Keyboard;

public interface IKeyboardService
{
    Task PressOne();
    void ClickAndLoot(int x, int y);
}