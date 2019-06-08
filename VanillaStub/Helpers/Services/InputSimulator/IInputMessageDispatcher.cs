using VanillaStub.Helpers.Services.InputSimulator.Native;

namespace VanillaStub.Helpers.Services.InputSimulator
{
    internal interface IInputMessageDispatcher
    {
        void DispatchInput(INPUT[] inputs);
    }
}