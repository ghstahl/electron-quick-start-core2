using System.Dynamic;
using CommandGraphQL;
using GraphQL.Types;
using P7.GraphQLCore;
using Programs.Models;
using Synoptic;

namespace ProgramsCommand
{
    public class MyQueryFieldRecordRegistrationBase : IQueryFieldRecordRegistration
    {
        public MyQueryFieldRecordRegistrationBase()
        {
        }

        public void AddGraphTypeFields(QueryCore queryCore)
        {
            var fieldName = "program";

            var fieldType = queryCore.FieldAsync<ProgramQueryOutput>(name: fieldName,
                description: null,
                arguments: new QueryArguments(new QueryArgument<ProgramQueryInput> { Name = "input" }),
                resolve: async context =>
                {
                    var input = context.GetArgument<IsInstalledQuery>("input");
                    var programs = new Programs();
                    var result = programs.GetIsInstalled(input);
                    var final = new IsInstalledOutput()
                    {
                        DisplayName = input.DisplayName,
                        IsInstalled = result.Result.Value
                    };
                    return final;
                },
                deprecationReason: null);
        }
    }
}