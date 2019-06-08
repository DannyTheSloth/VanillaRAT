using System;
using System.Collections.Generic;
using VanillaStub.Helpers.Services.InputSimulator.Native;

namespace VanillaStub.Helpers.Services.InputSimulator
{
    public interface IKeyboardSimulator
    {
        IMouseSimulator Mouse { get; }

        IKeyboardSimulator KeyDown(VirtualKeyCode keyCode);

        IKeyboardSimulator KeyPress(VirtualKeyCode keyCode);

        IKeyboardSimulator KeyPress(params VirtualKeyCode[] keyCodes);

        IKeyboardSimulator KeyUp(VirtualKeyCode keyCode);

        IKeyboardSimulator ModifiedKeyStroke(IEnumerable<VirtualKeyCode> modifierKeyCodes,
            IEnumerable<VirtualKeyCode> keyCodes);

        IKeyboardSimulator ModifiedKeyStroke(IEnumerable<VirtualKeyCode> modifierKeyCodes, VirtualKeyCode keyCode);

        IKeyboardSimulator ModifiedKeyStroke(VirtualKeyCode modifierKey, IEnumerable<VirtualKeyCode> keyCodes);

        IKeyboardSimulator ModifiedKeyStroke(VirtualKeyCode modifierKeyCode, VirtualKeyCode keyCode);

        IKeyboardSimulator TextEntry(string text);

        IKeyboardSimulator TextEntry(char character);

        IKeyboardSimulator Sleep(int millsecondsTimeout);

        IKeyboardSimulator Sleep(TimeSpan timeout);
    }
}