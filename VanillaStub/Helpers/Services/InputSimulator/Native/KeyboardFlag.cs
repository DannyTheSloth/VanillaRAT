using System;

namespace VanillaStub.Helpers.Services.InputSimulator.Native
{
    [Flags]
    internal enum KeyboardFlag : uint
    {
        ExtendedKey = 0x0001,

        KeyUp = 0x0002,

        Unicode = 0x0004,

        ScanCode = 0x0008
    }
}