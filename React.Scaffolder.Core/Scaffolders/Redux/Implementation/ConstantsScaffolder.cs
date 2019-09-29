using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;
using React.Scaffolder.Core.Scaffolders.Redux.Implementation.Base;
using React.Scaffolder.Infrastructure;
using React.Scaffolder.Infrastructure.Options;

namespace React.Scaffolder.Core.Scaffolders.Redux.Implementation
{
    public class ConstantsScaffolder : ScaffolderAbstractions, IJavaScriptScaffolder<string>
    {
        public void Scaffold(string folder)
        {
            var file = folder + @"\constants.js";

            var sb = new StringBuilder();
            sb.AppendLine("const constants = {");
            sb.AppendLine($"    {UpperEnitity}_GETALL_REQUEST:  '{UpperEnitity}_GETALL_REQUEST',");
            sb.AppendLine($"    {UpperEnitity}_GETALL_SUCCESS:  '{UpperEnitity}_GETALL_SUCCESS',");
            sb.AppendLine($"    {UpperEnitity}_GETBYID_REQUEST: '{UpperEnitity}_GETBYID_REQUEST',");
            sb.AppendLine($"    {UpperEnitity}_GETBYID_SUCCESS: '{UpperEnitity}_GETBYID_SUCCESS',");
            sb.AppendLine($"    {UpperEnitity}_CREATE_REQUEST:  '{UpperEnitity}_CREATE_REQUEST',");
            sb.AppendLine($"    {UpperEnitity}_CREATE_SUCCESS:  '{UpperEnitity}_CREATE_SUCCESS',");
            sb.AppendLine($"    {UpperEnitity}_UPDATE_REQUEST:  '{UpperEnitity}_UPDATE_REQUEST',");
            sb.AppendLine($"    {UpperEnitity}_UPDATE_SUCCESS:  '{UpperEnitity}_UPDATE_SUCCESS',");
            sb.AppendLine($"    {UpperEnitity}_DELETE_REQUEST:  '{UpperEnitity}_DELETE_REQUEST',");
            sb.AppendLine($"    {UpperEnitity}_DELETE_SUCCESS:  '{UpperEnitity}_DELETE_SUCCESS',");
            sb.AppendLine($"    {UpperEnitity}_LOADED:          '{UpperEnitity}_LOADED'");
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

        public ConstantsScaffolder(IOptions<EntitySettings> e, IOptions<GlobalSettings> g) : base(e, g)
        {
        }
    }
}