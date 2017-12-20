using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Command.Contracts;

namespace Command.Common
{
    public static class CommandAssemblysLoader
    {
        public static Assembly EntryAssembly { get; set; }
        private static List<Type> _commandAssemblyTypes;

        public static List<Type> CommandAssemblyTypes
        {
            get
            {
                if (_commandAssemblyTypes == null)
                {
                    LoadCommandAssemblyTypes();
                }

                return _commandAssemblyTypes.ToList();
            }
        }

        private static void LoadCommandAssemblyTypes()
        {
            if (_commandAssemblyTypes != null)
            {
                return;
            }
            var refAss = GetReferencingAssemblies(EntryAssembly);
            var calcs = from a in refAss
                        from t in a.GetTypes()
                where t.GetTypeInfo().GetCustomAttribute<CommandAssemblyAttribute>() != null
                      && t.GetTypeInfo().ImplementedInterfaces.Contains(typeof(ICommandAssembly))
                select t;

            _commandAssemblyTypes = calcs.OrderBy(t => t.GetTypeInfo().GetCustomAttribute<CommandAssemblyAttribute>().Order).ToList();
        }

        private static IEnumerable<Assembly> GetReferencingAssemblies(Assembly entryAssembly)
        {

            var assemblies = entryAssembly.GetReferencedAssemblies();

            foreach (var assemblyName in assemblies)
            {
                yield return Assembly.Load(assemblyName);
            }

        }
    }
}