namespace FishBrah.Service.Keyboard;

public interface IKeyboardService
{
    Task PressOne();
    void ClickAndLoot(uint x, uint y);
}