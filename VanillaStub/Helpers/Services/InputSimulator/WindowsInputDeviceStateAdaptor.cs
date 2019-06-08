using VanillaStub.Helpers.Services.InputSimulator.Native;

namespace VanillaStub.Helpers.Services.InputSimulator
{
    public class WindowsInputDeviceStateAdaptor : IInputDeviceStateAdaptor
    {
        public bool IsKeyDown(VirtualKeyCode keyCode)
        {
            short result = NativeMethods.GetKeyState((ushort) keyCode);
            return result < 0;
        }

        public bool IsKeyUp(VirtualKeyCode keyCode)
        {
            return !IsKeyDown(keyCode);
        }

        public bool IsHardwareKeyDown(VirtualKeyCode keyCode)
        {
            var result = NativeMethods.GetAsyncKeyState((ushort) keyCode);
            return result < 0;
        }

        public bool IsHardwareKeyUp(VirtualKeyCode keyCode)
        {
            return !IsHardwareKeyDown(keyCode);
        }

        public bool IsTogglingKeyInEffect(VirtualKeyCode keyCode)
        {
            short result = NativeMethods.GetKeyState((ushort) keyCode);
            return (result & 0x01) == 0x01;
        }
    }
}