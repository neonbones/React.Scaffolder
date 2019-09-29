using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;
using React.Scaffolder.Core.Scaffolders.Redux.Implementation.Base;
using React.Scaffolder.Infrastructure;
using React.Scaffolder.Infrastructure.Options;

namespace React.Scaffolder.Core.Scaffolders.Redux.Implementation
{
    public class ActionsScaffolder : ScaffolderAbstractions, IJavaScriptScaffolder<string>
    {
        public void Scaffold(string folder)
        {
            var file = folder + @"\actions.js";

            var sb = new StringBuilder();
            sb.AppendLine("import service from './service';");
            sb.AppendLine("import constants from './constants';");
            sb.AppendLine("import { actions as alert } from '../../alert/redux/actions';");
            sb.AppendLine("import history from '../../../infrastructure/history';");
            sb.AppendLine("import { buildForm } from '../../../infrastructure/utilities';");
            sb.AppendLine("");
            sb.AppendLine("const getAll = () => d => {");
            sb.AppendLine($"    d({UpperEnitity}_GETALL_REQUEST());");
            sb.AppendLine($"    return service.getAll().then(data => {{ d({UpperEnitity}_GETALL_SUCCESS(data)) }}, message => {{ alert.error(message) }})");
            sb.AppendLine("};");
            sb.AppendLine("");
            sb.AppendLine("const getById = (id) => d => {");
            sb.AppendLine($"    d({UpperEnitity}_GETBYID_REQUEST());");
            sb.AppendLine($"    return service.getById(id).then(data => {{ d({UpperEnitity}_GETBYID_SUCCESS(data)) }}, message => {{ alert.error(message) }})");
            sb.AppendLine("};");
            sb.AppendLine("");
            sb.AppendLine($"const create = ({FieldsAsString}) => d => {{");
            sb.AppendLine($"    d({UpperEnitity}_CREATE_REQUEST());");
            sb.AppendLine($"    const form = buildForm({{ {FieldsAsString} }});");
            sb.AppendLine("    return service.create(form).then(() => {");
            sb.AppendLine($"        d({UpperEnitity}_CREATE_SUCCESS())");
            sb.AppendLine($"        history.push('/Dashboard/{Entity}');");
            sb.AppendLine("        d(alert.success('Item has been successfully created.'));");
            sb.AppendLine("    }, message => { alert.error(message) })");
            sb.AppendLine("};");
            sb.AppendLine("");
            sb.AppendLine($"const update = (id, {FieldsAsString}) => d => {{");
            sb.AppendLine($"    d({UpperEnitity}_UPDATE_REQUEST());");
            sb.AppendLine($"    const form = buildForm({{ {FieldsAsString} }});");
            sb.AppendLine("    return service.update(id, form).then(() => {");
            sb.AppendLine($"        history.push('/Dashboard/{Entity}');");
            sb.AppendLine($"        d({UpperEnitity}_UPDATE_SUCCESS())");
            sb.AppendLine("        d(alert.success('Item has been successfully updated.'));");
            sb.AppendLine("    }, message => { alert.error(message) })");
            sb.AppendLine("};");
            sb.AppendLine("");
            sb.AppendLine("const _delete = (id) => d => {");
            sb.AppendLine($"    d({UpperEnitity}_DELETE_REQUEST());");
            sb.AppendLine("    return service._delete(id).then(() => {");
            sb.AppendLine($"        history.push('/Dashboard/{Entity}');");
            sb.AppendLine($"        d({UpperEnitity}_DELETE_SUCCESS())");
            sb.AppendLine("        d(alert.success('Item has been successfully deleted.'));");
            sb.AppendLine("    }, message => { alert.error(message) })}");
            sb.AppendLine("");
            sb.AppendLine($"const loaded = () => d => d({UpperEnitity}_LOADED());");
            sb.AppendLine("");
            sb.AppendLine($"const {UpperEnitity}_GETALL_REQUEST = () => {{ return {{ type: constants.{UpperEnitity}_GETALL_REQUEST }} }};");
            sb.AppendLine($"const {UpperEnitity}_GETALL_SUCCESS = (items) => {{ return {{ type: constants.{UpperEnitity}_GETALL_SUCCESS, items }} }};");
            sb.AppendLine($"const {UpperEnitity}_GETBYID_REQUEST = () => {{ return {{ type: constants.{UpperEnitity}_GETBYID_REQUEST }} }};");
            sb.AppendLine($"const {UpperEnitity}_GETBYID_SUCCESS = item => {{ return {{ type: constants.{UpperEnitity}_GETBYID_SUCCESS, item }} }};");
            sb.AppendLine($"const {UpperEnitity}_CREATE_REQUEST = () => {{ return {{ type: constants.{UpperEnitity}_CREATE_REQUEST }} }};");
            sb.AppendLine($"const {UpperEnitity}_CREATE_SUCCESS = () => {{ return {{ type: constants.{UpperEnitity}_CREATE_SUCCESS }} }};");
            sb.AppendLine($"const {UpperEnitity}_UPDATE_REQUEST = () => {{ return {{ type: constants.{UpperEnitity}_UPDATE_REQUEST }} }};");
            sb.AppendLine($"const {UpperEnitity}_UPDATE_SUCCESS = () => {{ return {{ type: constants.{UpperEnitity}_UPDATE_SUCCESS }} }};");
            sb.AppendLine($"const {UpperEnitity}_DELETE_REQUEST = () => {{ return {{ type: constants.{UpperEnitity}_DELETE_REQUEST }} }};");
            sb.AppendLine($"const {UpperEnitity}_DELETE_SUCCESS = () => {{ return {{ type: constants.{UpperEnitity}_DELETE_SUCCESS }} }};");
            sb.AppendLine($"const {UpperEnitity}_LOADED = () => {{ return {{ type: constants.{UpperEnitity}_LOADED }} }}");
            sb.AppendLine("");
            sb.AppendLine("const actions = { getAll, getById, create, update, _delete, loaded }");
            sb.AppendLine("export default actions;");

            using (var fs = new FileStream(file, FileMode.Create))
            {
                var array = Encoding.Default.GetBytes(sb.ToString());
                fs.Write(array, 0, array.Length);
            }

            Console.WriteLine(@"redux\actions.js scaffolded.");
        }

        public ActionsScaffolder(IOptions<EntitySettings> e, IOptions<GlobalSettings> g) : base(e, g)
        {
        }
    }
}
