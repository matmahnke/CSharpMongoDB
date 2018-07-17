using DAL.Impl.Interfaces;
using DAL.Infrastructure;
using DTO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl
{
    public class MercadoContext : BaseContext<Mercado>, ICRUD<Mercado>
    {
        public async Task<IEnumerable<Mercado>> GetAll()
        {
            IFindFluent<Mercado, Mercado> findFluent = CurrentType.Find(c => c.Ativo == true);
            List<Mercado> users = findFluent.ToList();
            return users;
        }

        public async Task<Mercado> GetById(string id)
        {
            IFindFluent<Mercado, Mercado> findFluent = CurrentType.Find(c => c.Id == id);
            findFluent.Limit(1);
            Mercado mercado = await findFluent.FirstOrDefaultAsync();
            return mercado;
        }

        public async Task<string> Insert(Mercado item)
        {
            await CurrentType.InsertOneAsync(item);
            return item.Id;
        }

        public async Task<string> Auth(Mercado item)
        {
            IFindFluent<Mercado, Mercado> findFluent = CurrentType.Find(c => c.Senha == item.Senha);
            List<Mercado> users = findFluent.ToList();
            return users.FirstOrDefault().Id;
        }
    }
}
