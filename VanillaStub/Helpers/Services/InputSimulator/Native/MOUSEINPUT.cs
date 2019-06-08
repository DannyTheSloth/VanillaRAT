using System;

namespace VanillaStub.Helpers.Services.InputSimulator.Native
{
#pragma warning disable 649
    internal struct MOUSEINPUT
    {
        public int X;

        public int Y;

        public uint MouseData;

        public uint Flags;

        public uint Time;

        public IntPtr ExtraInfo;
    }
#pragma warning restore 649
}