using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FishBrah.Service.Keyboard;

public class KeyboardService : IKeyboardService
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void keybd_event(uint bVk, uint bScan, uint dwFlags, uint dwExtraInfo);

    private const int MOUSE_RIGHT_CLICK = 0x6D;
    private const int KEYBOARD_SHIFT = 0xA0;
    private const int KEYBOARD_ONE = 0x31;

    public void PressOne()
    {
        keybd_event(KEYBOARD_ONE, 0,0,0);
    }
    
    public void ClickAndLoot(uint x, uint y)
    {
        mouse_event(MOUSE_RIGHT_CLICK | KEYBOARD_SHIFT, x, y, 0, 0);
    }
}