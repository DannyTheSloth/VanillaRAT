using System;

namespace VanillaStub.Helpers.Services.InputSimulator.Native
{
#pragma warning disable 649
    internal struct KEYBDINPUT
    {
        public ushort KeyCode;

        public ushort Scan;

        public uint Flags;

        public uint Time;

        public IntPtr ExtraInfo;
    }
#pragma warning restore 649
}