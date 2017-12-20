using System;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
using Command.Common;
using Newtonsoft.Json;
using Synoptic;

namespace SimpleCommands
{
    [Command(RouteBase = "v1/test")]
    public class TestCommands
    {
        
        [CommandAction(Route = "app-domain", Method = "GET")]
        public async Task<PrimitiveValue<string>> GetAppDomain()
        {
            return new PrimitiveValue<string>(AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
