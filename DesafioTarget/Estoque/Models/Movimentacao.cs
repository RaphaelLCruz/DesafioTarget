namespace DesafioTarget.Estoque.Models
{
    public class Movimentacao
    {
        public int CodigoProduto { get; set; } 

        public Guid  CodigoMovimentacao { get; set; } = Guid.NewGuid();

        public int Quantidade { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public TipoMovimentacao Tipo { get; set; }


    }
}
