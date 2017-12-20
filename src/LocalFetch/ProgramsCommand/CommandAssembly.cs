using System;
using System.Composition;
using Command.MEF.Contracts;
using Programs.Repository;

namespace ProgramsCommand
{
    [Export(typeof(ICommandAssembly))]
    [CommandAssembly(Name = "ProgramsCommand")]
    public class CommandAssembly : ICommandAssembly
    {
        public void Initialize()
        {
            var programsRepository = new ProgramsRepository();
            ProgramsCommand.Programs.ProgramsRepository = programsRepository;
            ProgramsCommand.Processes.ProgramsRepository = programsRepository;
        }
    }
}
