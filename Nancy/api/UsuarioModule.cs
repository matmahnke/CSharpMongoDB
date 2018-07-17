using BusinessLogicalLayer.BusinessLogicalLayer;
using DTO;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NancyApp.api
{
    public class UsuarioModule : NancyModule
    {
        public UsuarioModule()
        {
            Get["/user/{id}"] = _ =>
            {
                return "";
            };

            Post["/user", true] = async (_ , a) =>
            {
                IEnumerable<Usuario> usuarios = await UsuarioBusiness.GetAll();
                return usuarios;
            };
        }
    }
}
