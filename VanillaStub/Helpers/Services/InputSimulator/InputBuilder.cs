using System;
using System.Collections;
using System.Collections.Generic;
using VanillaStub.Helpers.Services.InputSimulator.Native;

namespace VanillaStub.Helpers.Services.InputSimulator
{
    internal class InputBuilder : IEnumerable<INPUT>
    {
        private readonly List<INPUT> _inputList;

        public InputBuilder()
        {
            _inputList = new List<INPUT>();
        }

        public INPUT this[int position] => _inputList[position];

        public IEnumerator<INPUT> GetEnumerator()
        {
            return _inputList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public INPUT[] ToArray()
        {
            return _inputList.ToArray();
        }

        public static bool IsExtendedKey(VirtualKeyCode keyCode)
        {
            if (keyCode == VirtualKeyCode.MENU ||
                keyCode == VirtualKeyCode.LMENU ||
                keyCode == VirtualKeyCode.RMENU ||
                keyCode == VirtualKeyCode.CONTROL ||
                keyCode == VirtualKeyCode.RCONTROL ||
                keyCode == VirtualKeyCode.INSERT ||
                keyCode == VirtualKeyCode.DELETE ||
                keyCode == VirtualKeyCode.HOME ||
                keyCode == VirtualKeyCode.END ||
                keyCode == VirtualKeyCode.PRIOR ||
                keyCode == VirtualKeyCode.NEXT ||
                keyCode == VirtualKeyCode.RIGHT ||
                keyCode == VirtualKeyCode.UP ||
                keyCode == VirtualKeyCode.LEFT ||
                keyCode == VirtualKeyCode.DOWN ||
                keyCode == VirtualKeyCode.NUMLOCK ||
                keyCode == VirtualKeyCode.CANCEL ||
                keyCode == VirtualKeyCode.SNAPSHOT ||
                keyCode == VirtualKeyCode.DIVIDE)
                return true;
            return false;
        }

        public InputBuilder AddKeyDown(VirtualKeyCode keyCode)
        {
            var down =
                new INPUT
                {
                    Type = (uint) InputType.Keyboard,
                    Data =
                    {
                        Keyboard =
                            new KEYBDINPUT
                            {
                                KeyCode = (ushort) keyCode,
                                Scan = 0,
                                Flags = IsExtendedKey(keyCode) ? (uint) KeyboardFlag.ExtendedKey : 0,
                                Time = 0,
                                ExtraInfo = IntPtr.Zero
                            }
                    }
                };

            _inputList.Add(down);
            return this;
        }

        public InputBuilder AddKeyUp(VirtualKeyCode keyCode)
        {
            var up =
                new INPUT
                {
                    Type = (uint) InputType.Keyboard,
                    Data =
                    {
                        Keyboard =
                            new KEYBDINPUT
                            {
                                KeyCode = (ushort) keyCode,
                                Scan = 0,
                                Flags = (uint) (IsExtendedKey(keyCode)
                                    ? KeyboardFlag.KeyUp | KeyboardFlag.ExtendedKey
                                    : KeyboardFlag.KeyUp),
                                Time = 0,
                                ExtraInfo = IntPtr.Zero
                            }
                    }
                };

            _inputList.Add(up);
            return this;
        }

        public InputBuilder AddKeyPress(VirtualKeyCode keyCode)
        {
            AddKeyDown(keyCode);
            AddKeyUp(keyCode);
            return this;
        }

        public InputBuilder AddCharacter(char character)
        {
            ushort scanCode = character;

            var down = new INPUT
            {
                Type = (uint) InputType.Keyboard,
                Data =
                {
                    Keyboard =
                        new KEYBDINPUT
                        {
                            KeyCode = 0,
                            Scan = scanCode,
                            Flags = (uint) KeyboardFlag.Unicode,
                            Time = 0,
                            ExtraInfo = IntPtr.Zero
                        }
                }
            };

            var up = new INPUT
            {
                Type = (uint) InputType.Keyboard,
                Data =
                {
                    Keyboard =
                        new KEYBDINPUT
                        {
                            KeyCode = 0,
                            Scan = scanCode,
                            Flags =
                                (uint) (KeyboardFlag.KeyUp | KeyboardFlag.Unicode),
                            Time = 0,
                            ExtraInfo = IntPtr.Zero
                        }
                }
            };

            if ((scanCode & 0xFF00) == 0xE000)
            {
                down.Data.Keyboard.Flags |= (uint) KeyboardFlag.ExtendedKey;
                up.Data.Keyboard.Flags |= (uint) KeyboardFlag.ExtendedKey;
            }

            _inputList.Add(down);
            _inputList.Add(up);
            return this;
        }

        public InputBuilder AddCharacters(IEnumerable<char> characters)
        {
            foreach (var character in characters) AddCharacter(character);
            return this;
        }

        public InputBuilder AddCharacters(string characters)
        {
            return AddCharacters(characters.ToCharArray());
        }

        public InputBuilder AddRelativeMouseMovement(int x, int y)
        {
            var movement = new INPUT {Type = (uint) InputType.Mouse};
            movement.Data.Mouse.Flags = (uint) MouseFlag.Move;
            movement.Data.Mouse.X = x;
            movement.Data.Mouse.Y = y;

            _inputList.Add(movement);

            return this;
        }

        public InputBuilder AddAbsoluteMouseMovement(int absoluteX, int absoluteY)
        {
            var movement = new INPUT {Type = (uint) InputType.Mouse};
            movement.Data.Mouse.Flags = (uint) (MouseFlag.Move | MouseFlag.Absolute);
            movement.Data.Mouse.X = absoluteX;
            movement.Data.Mouse.Y = absoluteY;

            _inputList.Add(movement);

            return this;
        }

        public InputBuilder AddAbsoluteMouseMovementOnVirtualDesktop(int absoluteX, int absoluteY)
        {
            var movement = new INPUT {Type = (uint) InputType.Mouse};
            movement.Data.Mouse.Flags = (uint) (MouseFlag.Move | MouseFlag.Absolute | MouseFlag.VirtualDesk);
            movement.Data.Mouse.X = absoluteX;
            movement.Data.Mouse.Y = absoluteY;

            _inputList.Add(movement);

            return this;
        }

        public InputBuilder AddMouseButtonDown(MouseButton button)
        {
            var buttonDown = new INPUT {Type = (uint) InputType.Mouse};
            buttonDown.Data.Mouse.Flags = (uint) ToMouseButtonDownFlag(button);

            _inputList.Add(buttonDown);

            return this;
        }

        public InputBuilder AddMouseXButtonDown(int xButtonId)
        {
            var buttonDown = new INPUT {Type = (uint) InputType.Mouse};
            buttonDown.Data.Mouse.Flags = (uint) MouseFlag.XDown;
            buttonDown.Data.Mouse.MouseData = (uint) xButtonId;
            _inputList.Add(buttonDown);

            return this;
        }

        public InputBuilder AddMouseButtonUp(MouseButton button)
        {
            var buttonUp = new INPUT {Type = (uint) InputType.Mouse};
            buttonUp.Data.Mouse.Flags = (uint) ToMouseButtonUpFlag(button);
            _inputList.Add(buttonUp);

            return this;
        }

        public InputBuilder AddMouseXButtonUp(int xButtonId)
        {
            var buttonUp = new INPUT {Type = (uint) InputType.Mouse};
            buttonUp.Data.Mouse.Flags = (uint) MouseFlag.XUp;
            buttonUp.Data.Mouse.MouseData = (uint) xButtonId;
            _inputList.Add(buttonUp);

            return this;
        }

        public InputBuilder AddMouseButtonClick(MouseButton button)
        {
            return AddMouseButtonDown(button).AddMouseButtonUp(button);
        }

        public InputBuilder AddMouseXButtonClick(int xButtonId)
        {
            return AddMouseXButtonDown(xButtonId).AddMouseXButtonUp(xButtonId);
        }

        public InputBuilder AddMouseButtonDoubleClick(MouseButton button)
        {
            return AddMouseButtonClick(button).AddMouseButtonClick(button);
        }

        public InputBuilder AddMouseXButtonDoubleClick(int xButtonId)
        {
            return AddMouseXButtonClick(xButtonId).AddMouseXButtonClick(xButtonId);
        }

        public InputBuilder AddMouseVerticalWheelScroll(int scrollAmount)
        {
            var scroll = new INPUT {Type = (uint) InputType.Mouse};
            scroll.Data.Mouse.Flags = (uint) MouseFlag.VerticalWheel;
            scroll.Data.Mouse.MouseData = (uint) scrollAmount;

            _inputList.Add(scroll);

            return this;
        }

        public InputBuilder AddMouseHorizontalWheelScroll(int scrollAmount)
        {
            var scroll = new INPUT {Type = (uint) InputType.Mouse};
            scroll.Data.Mouse.Flags = (uint) MouseFlag.HorizontalWheel;
            scroll.Data.Mouse.MouseData = (uint) scrollAmount;

            _inputList.Add(scroll);

            return this;
        }

        private static MouseFlag ToMouseButtonDownFlag(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LeftButton:
                    return MouseFlag.LeftDown;

                case MouseButton.MiddleButton:
                    return MouseFlag.MiddleDown;

                case MouseButton.RightButton:
                    return MouseFlag.RightDown;

                default:
                    return MouseFlag.LeftDown;
            }
        }

        private static MouseFlag ToMouseButtonUpFlag(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LeftButton:
                    return MouseFlag.LeftUp;

                case MouseButton.MiddleButton:
                    return MouseFlag.MiddleUp;

                case MouseButton.RightButton:
                    return MouseFlag.RightUp;

                default:
                    return MouseFlag.LeftUp;
            }
        }
    }
}