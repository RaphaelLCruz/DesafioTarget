using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DesafioTarget.Estoque.Models
{
    public class Produto
    {
        public int  CodigoProduto { get; set; } 

        public string DescricaoProduto { get; set; } = string.Empty;

        [JsonPropertyName("estoque")]

        public int QuantidadeEstoque { get; set; }
    }
}
