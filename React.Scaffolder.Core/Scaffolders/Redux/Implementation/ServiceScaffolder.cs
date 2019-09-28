using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;
using React.Scaffolder.Infrastructure;
using React.Scaffolder.Infrastructure.Options;

namespace React.Scaffolder.Core.Scaffolders.Redux.Implementation
{
    public class ServiceScaffolder : IJavaScriptScaffolder<string>
    {
        private readonly IOptions<GlobalSettings> _options;
        public ServiceScaffolder(IOptions<GlobalSettings> options)
        {
            _options = options;
        }

        public void Scaffold(string folder)
        {
            var file = folder + @"\service.js";
            
            var sb = new StringBuilder();
            sb.AppendLine($"import {{ service as crud }} from '{_options.Value.CrudService}';");
            sb.AppendLine();
            sb.AppendLine($"const getAll = () => crud.get('{_options.Value.ApiRoute}');");
            sb.AppendLine($"const getById = id => crud.get(`{_options.Value.ApiRoute}/${{id}}`);");
            sb.AppendLine($"const create = form => crud.post('{_options.Value.ApiRoute}', form);");
            sb.AppendLine($"const update = (id, form) => crud.put(`{_options.Value.ApiRoute}/${{id}}`, form);");
            sb.AppendLine($"const _delete = id => crud._delete(`{_options.Value.ApiRoute}/${{id}}`);");
            sb.AppendLine();
            sb.AppendLine("const service = { getAll, getById, create, update, _delete };");
            sb.AppendLine();
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
