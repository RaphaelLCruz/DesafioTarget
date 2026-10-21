

using DesafioTarget.Estoque.Models;

namespace DesafioTarget.Estoque.Services
{
    public class MovimentadorEstoque
    {

        public int AplicarMovimentacao(List<Produto> produtos, Movimentacao movimentacao)
        {
            Produto? achouProduto = null;
            foreach(var produto in produtos)
            {
                if(produto.CodigoProduto == movimentacao.CodigoProduto)
                {
                    achouProduto = produto;
                    break;
                }
            }

            if(achouProduto is null)
            {
                throw new ArgumentException($"Produto {movimentacao.CodigoProduto} não existe no estoque.");
            }

            if(movimentacao.Quantidade <= 0)
            {
                throw new ArgumentException($"“A quantidade deve ser maior que zero. Recebido:{movimentacao.Quantidade}");

            }

            if (movimentacao.Tipo == TipoMovimentacao.Entrada)
            {
                achouProduto.QuantidadeEstoque = achouProduto.QuantidadeEstoque + movimentacao.Quantidade;
            }
            else
            {
                if (movimentacao.Quantidade > achouProduto.QuantidadeEstoque)
                {
                    throw new ArgumentException($"Estoque insuficiente: {achouProduto.DescricaoProduto} tem {achouProduto.QuantidadeEstoque} e a saída pedida é de {movimentacao.Quantidade}");
                }

                achouProduto.QuantidadeEstoque = achouProduto.QuantidadeEstoque - movimentacao.Quantidade;
            }
            return achouProduto.QuantidadeEstoque;
        }
    }
}
