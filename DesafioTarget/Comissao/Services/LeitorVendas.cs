using DesafioTarget.Comissao.Models;
using System.Text.Json;

namespace DesafioTarget.Comissao.Services
{
    public class LeitorVendas
    {
        public List<Venda> LerVendas()
        {

            string fileName = "Comissao/Files/vendas.json";
            string jsonString = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            // transforma o json
            ArquivoVendas arquivoVendas = JsonSerializer.Deserialize<ArquivoVendas>(jsonString, options)!;

            return arquivoVendas.Vendas;
        }

    }
}
