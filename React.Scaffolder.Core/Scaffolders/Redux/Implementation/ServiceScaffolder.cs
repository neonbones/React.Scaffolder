using System;
using System.IO;
using System.Text;
using React.Scaffolder.Core.Scaffolders.Redux.Implementation.Base;
using React.Scaffolder.Infrastructure;

namespace React.Scaffolder.Core.Scaffolders.Redux.Implementation
{
    public class ServiceScaffolder : ScaffolderAbstractions, IJavaScriptScaffolder<string>
    {
        public void Scaffold(string folder)
        {
            var file = folder + @"\service.js";
            
            var sb = new StringBuilder();
            sb.AppendLine("import { service as crud } from '../../../services/crud.service';");
            sb.AppendLine("");
            sb.AppendLine($"const getAll = () => crud.get('{ApiRoute}');");
            sb.AppendLine($"const getById = id => crud.get(`{ApiRoute}/${{id}}`);");
            sb.AppendLine($"const create = form => crud.post('{ApiRoute}', form);");
            sb.AppendLine($"const update = (id, form) => crud.put(`{ApiRoute}/${{id}}`, form);");
            sb.AppendLine($"const _delete = id => crud._delete(`{ApiRoute}/${{id}}`);");
            sb.AppendLine("");
            sb.AppendLine("const service = { getAll, getById, create, update, _delete };");
            sb.AppendLine("");
            sb.AppendLine("export default service;");

            using (var fs = new FileStream(file, FileMode.Create))
            {
                var array = Encoding.Default.GetBytes(sb.ToString());
                fs.Write(array, 0, array.Length);
            }

            Console.WriteLine(@"redux\service.js scaffolded.");
        }
    }
}
