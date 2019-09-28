using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;
using React.Scaffolder.Infrastructure;
using React.Scaffolder.Infrastructure.Options;

namespace React.Scaffolder.Core.Scaffolders.Redux.Implementation
{
    public class ConstantsScaffolder : IJavaScriptScaffolder<string>
    {
        private readonly IOptions<EntitySettings> _options;
        public ConstantsScaffolder(IOptions<EntitySettings> options)
        {
            _options = options;
        }

        public void Scaffold(string folder)
        {
            var file = folder + @"\constants.js";

            var entity = _options.Value.Name.ToUpperInvariant();

            var sb = new StringBuilder();
            sb.AppendLine("const constants = {");
            sb.AppendLine($"    {entity}_GETALL_REQUEST:  '{entity}_GETALL_REQUEST',");
            sb.AppendLine($"    {entity}_GETALL_SUCCESS:  '{entity}_GETALL_SUCCESS',");
            sb.AppendLine($"    {entity}_GETBYID_REQUEST: '{entity}_GETBYID_REQUEST',");
            sb.AppendLine($"    {entity}_GETBYID_SUCCESS: '{entity}_GETBYID_SUCCESS',");
            sb.AppendLine($"    {entity}_CREATE_REQUEST:  '{entity}_CREATE_REQUEST',");
            sb.AppendLine($"    {entity}_CREATE_SUCCESS:  '{entity}_CREATE_SUCCESS',");
            sb.AppendLine($"    {entity}_UPDATE_REQUEST:  '{entity}_UPDATE_REQUEST',");
            sb.AppendLine($"    {entity}_UPDATE_SUCCESS:  '{entity}_UPDATE_SUCCESS',");
            sb.AppendLine($"    {entity}_DELETE_REQUEST:  '{entity}_DELETE_REQUEST',");
            sb.AppendLine($"    {entity}_DELETE_SUCCESS:  '{entity}_DELETE_SUCCESS',");
            sb.AppendLine($"    {entity}_LOADED:          '{entity}_LOADED'");
            sb.AppendLine("};");
            sb.AppendLine();
            sb.AppendLine("export default constants;");

            using (var fs = new FileStream(file, FileMode.Create))
            {
                var array = Encoding.Default.GetBytes(sb.ToString());
                fs.Write(array, 0, array.Length);
            }

            Console.WriteLine(@"redux\constants.js scaffolded.");
        }
    }
}
