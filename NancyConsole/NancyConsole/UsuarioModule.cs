using BusinessLogicalLayer.BusinessLogicalLayer;
using DTO;
using Nancy;
using Nancy.Extensions;
using Nancy.Json;
using Nancy.ModelBinding;
using NancyConsole.Models;
using NancyConsole.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyConsole
{
    public class UsuarioModule : Nancy.NancyModule
    {
        public UsuarioModule()
        {
            Get["/Usuario/{UsuarioId}", true] = async (_, a) =>
            {
                var id = _.UsuarioId;
                IEnumerable<DTO.Usuario> usuarios = await BusinessLogicalLayer.BusinessLogicalLayer.UsuarioBusiness.GetById(id);
                List<DTO.Usuario> produto = usuarios.ToList();
                return Response.AsJson(produto);
            };

            Post["/Usuario/Create", true] = async (_,a) =>
            {
                Usuario usuario = this.Bind<Usuario>();
                return await UsuarioBusiness.Insert(usuario);
            };

            Post["/Usuario/Auth", true] = async (_, a) =>
            {
                AuthModel usuario = new JavaScriptSerializer().Deserialize<AuthModel>(this.Request.Body.AsString());
                var user = Mapper<Usuario, AuthModel>.Map(usuario);
                return await UsuarioBusiness.Auth(user);
            };
        }
    }
}
