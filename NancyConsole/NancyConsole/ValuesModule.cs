using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using BusinessLogicalLayer.BusinessLogicalLayer;

namespace NancyConsole
{
    public class ValuesModule : Nancy.NancyModule
    {
        public ValuesModule()
        {
            Get["/Values", true] = async (_, a) =>
            {
                Task<IEnumerable<DTO.Usuario>> usuarios = BusinessLogicalLayer.BusinessLogicalLayer.UsuarioBusiness.GetAll();
                usuarios.Wait();
                return Response.AsJson(usuarios);
            };

            Post["/values"] = _ =>
            {
                var jsonString = this.Request.Body.AsString();

                var user = new DTO.Usuario() { Nome = "teste", Email = "teste", Senha = "1234", Ativo = true };

                UsuarioBusiness.Insert(user);

                return Response.AsJson(jsonString);
            };
        }
    }
}
