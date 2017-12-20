using System.Composition;
using Command.MEF.Contracts;

namespace CommandPOCCallbacks
{
    [Export(typeof(ICommandAssembly))]
    [CommandAssembly(Name = "Command.POC.Callbacks")]
    public class CommandAssembly : ICommandAssembly
    {
        public void Initialize()
        {

        }
    }
}