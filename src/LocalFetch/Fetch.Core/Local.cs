using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Command.MEF.Common;
using Command.MEF.Contracts;

using Newtonsoft.Json;
using Synoptic;
 

namespace Fetch.Core
{
    public class Local
    {
        public static CommandCompositionHelper CommandCompositionHelper { get; set; }
        public static List<string> Anchors => new List<string>();
        public void Initialize()
        {

            if (CommandCompositionHelper == null)
            {
                Anchors.Add(ProgramsCommand.Anchor.FullName);
                Anchors.Add(CommandFileLoader.Anchor.FullName);
                Anchors.Add(CommandPOCCallbacks.Anchor.FullName);
                Anchors.Add(SimpleCommands.Anchor.FullName);

                CommandAssemblysLoader.EntryAssembly = Assembly.GetAssembly(typeof(Local));
    //            var dd = ProgramsCommand.Anchor.Name;
                var root = Assembly.GetAssembly(typeof(Local)).Location;
                var dir = Path.GetDirectoryName(root);
                var components = dir;
          //      var dd = ProgramsCommand.Programs.ProgramsRepository;
                //  var components = Path.Combine(dir, "components");
                CommandCompositionHelper = new CommandCompositionHelper(components);
                CommandCompositionHelper.AssembleCommandComponents();
                CommandCompositionHelper.Initialize();


         //       JsonFile.RootFolder = ""; // just making sure that the dll gets copied
            }
        }

        public Local()
        {
            Initialize();
        }

        public async Task<object> Invoke(object input)
        {
            throw new Exception("no magic invokes allowed");
        }

        public async Task<object> Fetch(object input)
        {
            Initialize();
            //return await Task.Run(() => JsonConvert.SerializeObject(input, Formatting.Indented));
            Input strongInput = null;

            string error = null;
            RunResult runResult = null;
            string jsonRunResult = null;
            Response response = new Response() { StatusCode = 404, StatusMessage = "", Value = null };
            try
            {
                strongInput = input.ToInput();
                ExpandoObject expandoInput = input as ExpandoObject;
                var expandoDict = expandoInput as IDictionary<string, object>;

                ExpandoObject body = expandoDict["body"] as ExpandoObject;

                var routeQuery = new RouteQuery()
                {
                    Body = strongInput.Body,
                    Method = strongInput.Method,
                    Route = strongInput.Url
                };
                runResult = await (new CommandRunner()).RunViaRouteAsync(routeQuery);
                response = new Response() { StatusCode = 200, StatusMessage = "OK", Value = runResult.Value };
                if (runResult.ErrorCode != 0)
                {
                    response.StatusCode = 404;
                    response.StatusMessage = "Not Found";
                    response.Value = routeQuery;
                }
            }
            catch (Exception e)
            {
                error = e.Message;
                response.StatusMessage = error;
            }
            var expandoValue = response.ToExpandoObject();
            return expandoValue;
        }
   
    }
}
