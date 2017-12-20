using System.Composition;
using Command.MEF.Contracts;

namespace CommandFileLoader
{
    [Export(typeof(ICommandAssembly))]
    [CommandAssembly(Name = "FileLoader")]
    public class MyCommandAssembly : ICommandAssembly
    {
        public void Initialize()
        {

        }
    }
}