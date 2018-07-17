using BusinessLogicalLayer.BusinessLogicalLayer;
using DTO;
using Nancy;
using Nancy.Extensions;
using Nancy.Json;
using NancyConsole.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyConsole
{
    public class MercadoModule: NancyModule
    {
        public MercadoModule()
        {
            Get["/Mercado/{MercadoId}", true] = async (_, a) =>
            {
                var id = _.MercadoId;
                Task<DTO.Mercado> mercados = BusinessLogicalLayer.BusinessLogicalLayer.MercadoBusiness.GetById(id);
                mercados.Wait();
                return new JavaScriptSerializer().Serialize(mercados);
            };

            Post["/Mercado/Create", true] = async (_, a) =>
            {
                Mercado mercado = new JavaScriptSerializer().Deserialize<Mercado>(this.Request.Body.AsString());
                return await MercadoBusiness.Insert(mercado);
            };

            Post["/Mercado/Auth", true] = async (_, a) =>
            {
                AuthModel mercado = new JavaScriptSerializer().Deserialize<AuthModel>(this.Request.Body.AsString());
                Mercado m = Mapper<Mercado, AuthModel>.Map(mercado);
                return await MercadoBusiness.Auth(m);
            };
        }
    }
}
