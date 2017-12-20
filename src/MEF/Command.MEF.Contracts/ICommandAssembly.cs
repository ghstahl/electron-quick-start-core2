using System;
using System.Collections.Generic;

namespace Command.MEF.Contracts
{
    public interface ICommandAssembly
    {
        void Initialize();
    }
    public interface ICommandAssemblyProvider
    {
        IDictionary<string, ICommandAssembly> GetCommandAssemblies();
        IEnumerable<string> GetNames();
        IEnumerable<Type> GetTypes();
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class CommandAssemblyAttribute : Attribute
    {
        public CommandAssemblyAttribute()
        {
            Order = -1;
            ShowOnChart = true;
        }

        public string Name { get; set; }
        public int Order { get; set; }
        public bool ShowOnChart { get; set; }
        public string DisplayLabel { get; set; }
    }
}
