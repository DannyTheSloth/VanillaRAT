using System;

namespace VanillaStub.Helpers.Services.InputSimulator.Native
{
    [Flags]
    internal enum MouseFlag : uint
    {
        Move = 0x0001,

        LeftDown = 0x0002,

        LeftUp = 0x0004,

        RightDown = 0x0008,

        RightUp = 0x0010,

        MiddleDown = 0x0020,

        MiddleUp = 0x0040,

        XDown = 0x0080,

        XUp = 0x0100,

        VerticalWheel = 0x0800,

        HorizontalWheel = 0x1000,

        VirtualDesk = 0x4000,

        Absolute = 0x8000
    }
}