using DesafioTarget.Comissao.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DesafioTarget.Estoque.Models
{
    public class ArquivoEstoque
    {
        [JsonPropertyName("estoque")]
        public List<Produto> Produtos { get; set; } = new List<Produto>();

    }
}
