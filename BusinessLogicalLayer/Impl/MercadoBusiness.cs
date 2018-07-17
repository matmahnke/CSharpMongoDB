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
    public static class MercadoBusiness
    {
        public static async Task<IEnumerable<Mercado>> GetAll()
        {
            return await new MercadoContext().GetAll();
        }

        public static async Task<Mercado> GetById(string id)
        {
            return await new MercadoContext().GetById(id);
        }

        public static async Task<string> Insert(Mercado item)
        {
            return await new MercadoContext().Insert(item);
        }

        public static async Task<string> Auth(Mercado item)
        {
            return await new MercadoContext().Auth(item);
        }
    }
}
