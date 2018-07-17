using BusinessLogicalLayer.BusinessLogicalLayer;
using DTO;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Extensions;
using Nancy.Json;
using Nancy.Responses.Negotiation;
using NancyConsole.Models;
using NancyConsole.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NancyConsole
{
    public class ProdutoModule : Nancy.NancyModule
    {
        public ProdutoModule()
        {
            Get["/Produto/", true] = async (parameters, a) =>
            {
                IEnumerable<DTO.Produto> produtos = await BusinessLogicalLayer.BusinessLogicalLayer.ProdutoBusiness.GetAll();
                List<DTO.Produto> produto = produtos.ToList();
                return Response.AsJson(produto);
            };

            Get["/Produto/{MercadoId}", true] = async (_, a) =>
            {
                var id = _.MercadoId;
                IEnumerable<DTO.Produto> produtos = await BusinessLogicalLayer.BusinessLogicalLayer.ProdutoBusiness.GetByMercadoId(id);
                List<DTO.Produto> produto = produtos.ToList();
                return Response.AsJson(produto);
            };

            Post["/Produto/Create", true] = async (_, a) =>
            {
                //Imagens muito grandes dão timeout ao ler o json (adicionar validação de tamanho de imagem no angular)
                var prod = new Produto();
                object teste = new JavaScriptSerializer().Deserialize<object>(this.Request.Body.AsString());
                foreach (PropertyInfo prop in teste.GetType().GetProperties())
                {
                    //prod.Nome = prop.Name == "Nome" ?? prop.().ToString() : null;
                }
                Produto produto = Mapper<Produto, ProdutoModel>.Map(new JavaScriptSerializer().Deserialize<ProdutoModel>(this.Request.Body.AsString()));
                return await ProdutoBusiness.Insert(produto);
            };

            Get["/Produto/Busca/{Busca}", true] = async (_, a) =>
            {
                var Busca = _.Busca;
                IEnumerable<DTO.Produto> produtos = await BusinessLogicalLayer.BusinessLogicalLayer.ProdutoBusiness.FindByName(Busca);
                List<DTO.Produto> produto = produtos.ToList();
                return Response.AsJson(produto);
            };
        }
    }
}
