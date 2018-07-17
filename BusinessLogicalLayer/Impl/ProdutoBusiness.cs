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
    public static class ProdutoBusiness
    {
        public static async Task<IEnumerable<Produto>> GetAll()
        {
            return await new ProdutoContext().GetAll();
        }

        public static async Task<Produto> GetById(string id)
        {
            throw new NotImplementedException();
        }
        public static async Task<IEnumerable<Produto>> GetByMercadoId(string id)
        {
            var retorno = await new ProdutoContext().GetAll();
            return retorno.Where(c => c.Mercado == id);
        }

        public static async Task<string> Insert(Produto item)
        {
            return await new ProdutoContext().Insert(item);
        }

        public static async Task<IEnumerable<Produto>> FindByName(string name)
        {
            return await new ProdutoContext().FindByName(new Produto() { Nome = name });
        }
    }
}
