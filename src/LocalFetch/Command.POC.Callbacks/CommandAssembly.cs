﻿using Command.MEF.Contracts;

namespace CommandPOCCallbacks
{
    [CommandAssembly(AssemblyType = typeof(CommandAssembly))]
    public class CommandAssembly : ICommandAssembly
    {
        public void Initialize()
        {

        }
    }
}