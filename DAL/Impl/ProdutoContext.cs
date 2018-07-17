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
using DTO.DataAnnotations;

namespace DAL.Impl
{
    public class ProdutoContext : BaseContext<Produto>, ICRUD<Produto>
    {
        public async Task<IEnumerable<Produto>> GetAll()
        {
            List<Produto> users;
            try
            {
                IFindFluent<Produto, Produto> findFluent;
                findFluent = CurrentType.Find(c => c.Ativo == true);
                users = findFluent.ToList();
            }
            catch (Exception e)
            {

                throw;
            }
            return users;
        }

        public Task<Produto> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Insert(Produto item)
        {
            await CurrentType.InsertOneAsync(item);
            return item.Id;
        }
        public async Task<IEnumerable<Produto>> FindByName(Produto user)
        {
            IFindFluent<Produto, Produto> findFluent = CurrentType.Find(c => c.Ativo == true && c.Nome.Contains(user.Nome));
            List<Produto> users = findFluent.ToList();
            return users;
        }
    }
}
