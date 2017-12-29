using Autofac;
using GraphQL.Types;
using Module = Autofac.Module;

namespace CommandGraphQL
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProgramQueryInput>();
            builder.RegisterType<ProgramQueryOutput>();
        }
    }
    public class ProgramQueryOutput : ObjectGraphType
    {
        public ProgramQueryOutput()
        {
            Name = "ProgramQueryOutput";
            Field<NonNullGraphType<StringGraphType>>("displayName");
            Field<NonNullGraphType<BooleanGraphType>>("isInstalled");
           
        }
    }
    public class ProgramQueryInput : InputObjectGraphType
    {
        public ProgramQueryInput()
        {
            Name = "ProgramQueryInput";
            Field<NonNullGraphType<StringGraphType>>("displayName");
        }
    }
    
}