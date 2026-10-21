using DesafioTarget.Estoque.Models;
using System.Text.Json;

namespace DesafioTarget.Estoque.Service

{
    public class LeitorEstoque
    {

        public List<Produto>LerEstoque()
        {
            string fileName = "Estoque/Files/estoque.json";
            string jsonString = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            ArquivoEstoque arquivoEstoque = JsonSerializer.Deserialize<ArquivoEstoque>(jsonString, options)!;


            return arquivoEstoque.Produtos;
        }
    }
}
