using DesafioTarget.Comissao.Models;

namespace DesafioTarget.Comissao.Services
{
    public class CalculadoraComissao
    {
        public decimal CalcularComissao(decimal valor)
        {
            decimal comissao = valor switch
            {
                < 100 => 0m,
                >= 100.00m and < 500.0m => valor * 0.01m,
                >= 500 => valor * 0.05m
            };

            return Math.Round(comissao, 2, MidpointRounding.AwayFromZero);
        }

        public List<ComissaoVendedor> AgruparComissao(List<Venda> vendas)
        {
            List<ComissaoVendedor> resultado = new List<ComissaoVendedor>();

            foreach(var venda in vendas)
            {
                decimal comissao = CalcularComissao(venda.Valor);
                ComissaoVendedor? existente = resultado.Find(c => c.Vendedor == venda.Vendedor);
                if (existente == null)
                    resultado.Add(new ComissaoVendedor {Vendedor = venda.Vendedor, Comissao = comissao});
                else
                    existente.Comissao = existente.Comissao + comissao;
            }

            return resultado;
        }

    }
}
