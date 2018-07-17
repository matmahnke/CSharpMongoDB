using DAL.Impl.Interfaces;
using DAL.Infrastructure;
using DTO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Bson;

namespace DAL.Impl
{
    public class UsuarioContext : BaseContext<Usuario>, ICRUD<Usuario>
    {
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            IFindFluent<Usuario, Usuario> findFluent = CurrentType.Find(c => c.Ativo == true);
            List<Usuario> users = findFluent.ToList();
            return users;
        }

        public Task<Usuario> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Insert(Usuario item)
        {
            await CurrentType.InsertOneAsync(item);
            return item.Id;
        }

        public async Task<string> Auth(Usuario item)
        {
            IFindFluent<Usuario, Usuario> findFluent = CurrentType.Find(c => c.Email == item.Email && c.Senha == item.Senha);
            List<Usuario> users = findFluent.ToList();
            return users.FirstOrDefault().Id;
        }
    }
}
