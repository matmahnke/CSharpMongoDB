using DAL.Impl.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Impl;

namespace BusinessLogicalLayer.BusinessLogicalLayer
{
    public static class UsuarioBusiness
    {
        public static async Task<IEnumerable<Usuario>> GetAll()
        {
            return await new UsuarioContext().GetAll();
        }

        public static async Task<Usuario> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public static async Task<string> Insert(Usuario item)
        {
            return await new UsuarioContext().Insert(item);
        }

        public static async Task<string> Auth(Usuario item)
        {
            return await new UsuarioContext().Auth(item);
        }
    }
}
