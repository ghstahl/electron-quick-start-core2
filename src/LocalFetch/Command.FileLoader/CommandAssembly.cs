﻿using Command.MEF.Contracts;

namespace CommandFileLoader
{
    [CommandAssembly(AssemblyType = typeof(CommandAssembly))]
    public class CommandAssembly : ICommandAssembly
    {
        public void Initialize()
        {

        }
    }
}