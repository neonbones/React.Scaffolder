using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;
using React.Scaffolder.Infrastructure;
using React.Scaffolder.Infrastructure.Options;

namespace React.Scaffolder.Core.Scaffolders.Redux.Implementation
{
    public class ReducerScaffolder : IJavaScriptScaffolder<string>
    {
        private readonly IOptions<EntitySettings> _options;
        public ReducerScaffolder(IOptions<EntitySettings> options)
        {
            _options = options;
        }
        public void Scaffold(string folder)
        {
            var file = folder + @"\reducer.js";

            var entity = _options.Value.Name.ToUpperInvariant();
            var lower = _options.Value.Name.ToLowerInvariant();

            var sb = new StringBuilder();           
            sb.AppendLine("import constants from './constants';");
            sb.AppendLine("const initialState = { loading: true };");
            sb.AppendLine();
            sb.AppendLine($"const {lower} = (state = initialState, action) => {{");
            sb.AppendLine("    switch (action.type) {");
            sb.AppendLine($"        case constants.{entity}_GETALL_REQUEST:  return {{ loading: true }};");
            sb.AppendLine($"        case constants.{entity}_GETALL_SUCCESS:  return {{ items: action.items, loading: false }};");
            sb.AppendLine($"        case constants.{entity}_GETBYID_REQUEST: return {{ loading: true }};");
            sb.AppendLine($"        case constants.{entity}_GETBYID_SUCCESS: return {{ item: action.item, loading: false }};");
            sb.AppendLine($"        case constants.{entity}_CREATE_REQUEST:  return {{ loading: true }};");
            sb.AppendLine($"        case constants.{entity}_CREATE_SUCCESS:  return {{ loading: false }};");
            sb.AppendLine($"        case constants.{entity}_UPDATE_REQUEST:  return {{ loading: true }};");
            sb.AppendLine($"        case constants.{entity}_UPDATE_SUCCESS:  return state;");
            sb.AppendLine($"        case constants.{entity}_DELETE_REQUEST:  return {{ loading: true }};");
            sb.AppendLine($"        case constants.{entity}_DELETE_SUCCESS:  return {{ loading: false }};");
            sb.AppendLine($"        case constants.{entity}_LOADED:          return {{ loading: false }};");
            sb.AppendLine("        default: return state;");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine($"export default {lower};");

            using (var fs = new FileStream(file, FileMode.Create))
            {
                var array = Encoding.Default.GetBytes(sb.ToString());
                fs.Write(array, 0, array.Length);
            }

            Console.WriteLine(@"redux\reducer.js scaffolded.");
        }
    }
}
