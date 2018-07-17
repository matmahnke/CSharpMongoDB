using DTO.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [TableName("Produtos")]
    public class Produto : Entity
    {
        [BsonRepresentation(BsonType.String)]
        public string Mercado { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Peso { get; set; }
        public string Imagem { get; set; }
    }
}
