using System;

namespace VanillaStub.Helpers.Services.InputSimulator
{
    public interface IMouseSimulator
    {
        IKeyboardSimulator Keyboard { get; }

        IMouseSimulator MoveMouseBy(int pixelDeltaX, int pixelDeltaY);

        IMouseSimulator MoveMouseTo(double absoluteX, double absoluteY);

        IMouseSimulator MoveMouseToPositionOnVirtualDesktop(double absoluteX, double absoluteY);

        IMouseSimulator LeftButtonDown();

        IMouseSimulator LeftButtonUp();

        IMouseSimulator LeftButtonClick();

        IMouseSimulator LeftButtonDoubleClick();

        IMouseSimulator RightButtonDown();

        IMouseSimulator RightButtonUp();

        IMouseSimulator RightButtonClick();

        IMouseSimulator RightButtonDoubleClick();

        IMouseSimulator XButtonDown(int buttonId);

        IMouseSimulator XButtonUp(int buttonId);

        IMouseSimulator XButtonClick(int buttonId);

        IMouseSimulator XButtonDoubleClick(int buttonId);

        IMouseSimulator VerticalScroll(int scrollAmountInClicks);

        IMouseSimulator HorizontalScroll(int scrollAmountInClicks);

        IMouseSimulator Sleep(int millsecondsTimeout);

        IMouseSimulator Sleep(TimeSpan timeout);
    }
}