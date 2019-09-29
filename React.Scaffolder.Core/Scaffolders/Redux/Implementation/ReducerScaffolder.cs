using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;
using React.Scaffolder.Core.Scaffolders.Redux.Implementation.Base;
using React.Scaffolder.Infrastructure;
using React.Scaffolder.Infrastructure.Options;

namespace React.Scaffolder.Core.Scaffolders.Redux.Implementation
{
    public class ReducerScaffolder : ScaffolderAbstractions, IJavaScriptScaffolder<string>
    {
        public void Scaffold(string folder)
        {
            var file = folder + @"\reducer.js";

            var sb = new StringBuilder();           
            sb.AppendLine("import constants from './constants';");
            sb.AppendLine("const initialState = { loading: true };");
            sb.AppendLine();
            sb.AppendLine($"const {LowerEntity} = (state = initialState, action) => {{");
            sb.AppendLine("    switch (action.type) {");
            sb.AppendLine($"        case constants.{UpperEnitity}_GETALL_REQUEST:  return {{ loading: true }};");
            sb.AppendLine($"        case constants.{UpperEnitity}_GETALL_SUCCESS:  return {{ items: action.items, loading: false }};");
            sb.AppendLine($"        case constants.{UpperEnitity}_GETBYID_REQUEST: return {{ loading: true }};");
            sb.AppendLine($"        case constants.{UpperEnitity}_GETBYID_SUCCESS: return {{ item: action.item, loading: false }};");
            sb.AppendLine($"        case constants.{UpperEnitity}_CREATE_REQUEST:  return {{ loading: true }};");
            sb.AppendLine($"        case constants.{UpperEnitity}_CREATE_SUCCESS:  return {{ loading: false }};");
            sb.AppendLine($"        case constants.{UpperEnitity}_UPDATE_REQUEST:  return {{ loading: true }};");
            sb.AppendLine($"        case constants.{UpperEnitity}_UPDATE_SUCCESS:  return state;");
            sb.AppendLine($"        case constants.{UpperEnitity}_DELETE_REQUEST:  return {{ loading: true }};");
            sb.AppendLine($"        case constants.{UpperEnitity}_DELETE_SUCCESS:  return {{ loading: false }};");
            sb.AppendLine($"        case constants.{UpperEnitity}_LOADED:          return {{ loading: false }};");
            sb.AppendLine("        default: return state;");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine($"export default {LowerEntity};");

            using (var fs = new FileStream(file, FileMode.Create))
            {
                var array = Encoding.Default.GetBytes(sb.ToString());
                fs.Write(array, 0, array.Length);
            }

            Console.WriteLine(@"redux\reducer.js scaffolded.");
        }

        public ReducerScaffolder(IOptions<EntitySettings> e, IOptions<GlobalSettings> g) : base(e, g)
        {
        }
    }
}
