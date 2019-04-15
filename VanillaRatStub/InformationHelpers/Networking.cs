using Telepathy;

namespace VanillaRatStub.InformationHelpers
{
    internal class Networking
    {
        public static Client MainClient = new Client();
        public static string CurrentMessage { get; set; }
        public static bool ChatClosing { get; set; }
    }
}