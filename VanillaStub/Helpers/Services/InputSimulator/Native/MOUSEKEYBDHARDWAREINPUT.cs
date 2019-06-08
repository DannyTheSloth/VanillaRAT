using System.Runtime.InteropServices;

namespace VanillaStub.Helpers.Services.InputSimulator.Native
{
#pragma warning disable 649
    [StructLayout(LayoutKind.Explicit)]
    internal struct MOUSEKEYBDHARDWAREINPUT
    {
        [FieldOffset(0)] public MOUSEINPUT Mouse;

        [FieldOffset(0)] public KEYBDINPUT Keyboard;

        [FieldOffset(0)] public HARDWAREINPUT Hardware;
    }
#pragma warning restore 649
}