namespace VanillaStub.Helpers.Services.InputSimulator
{
    public interface IInputSimulator
    {
        IKeyboardSimulator Keyboard { get; }

        IMouseSimulator Mouse { get; }

        IInputDeviceStateAdaptor InputDeviceState { get; }
    }
}