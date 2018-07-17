using DTO.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [TableName("Mercados")]
    public class Mercado : Login
    {
        public string Endereco { get; set; }
        public string Imagem { get; set; }
    }
}
