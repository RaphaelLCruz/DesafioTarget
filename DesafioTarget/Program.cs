using DesafioTarget.Comissao.Services;
using DesafioTarget.Estoque.Models;
using DesafioTarget.Estoque.Service;
using DesafioTarget.Estoque.Services;
using DesafioTarget.Juros.Services;
using System.Globalization;

Console.WriteLine("Desafio 1\n");


var leitor = new LeitorVendas();
var listaVendas = leitor.LerVendas();
foreach(var venda in listaVendas)
{
    Console.WriteLine($"Vendedor: {venda.Vendedor}");
    Console.WriteLine($"Vendas:{venda.Valor}\n");
}

Console.WriteLine("------------------------------------------------------------------------------------\n");


var calculadoraComissao = new CalculadoraComissao();
var comissoes = calculadoraComissao.AgruparComissao(listaVendas);

foreach (var comissao in comissoes)
{
    Console.WriteLine($"Vendedor: {comissao.Vendedor}");
    Console.WriteLine($"Comissão: {comissao.Comissao}\n");
}
Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
Console.WriteLine("Desafio 2\n");


var leitor1 = new LeitorEstoque();
var produtos = leitor1.LerEstoque();

foreach(var produto in produtos)
{
    Console.WriteLine($"Estoque: {produto.QuantidadeEstoque}, Codigo Produto: {produto.CodigoProduto}, Descricao Produto: {produto.DescricaoProduto}\n");

}
Console.Write("Digite o código do produto: ");
string? textoDigitado = Console.ReadLine();
if(!int.TryParse(textoDigitado, out int codigoProduto))
{
    Console.WriteLine("Código inválido.");
    return;
}

Console.Write("Tipo de movimentação (1 - Entrada, 2 - Saída): ");
string? textoTipo = Console.ReadLine();
if(!int.TryParse(textoTipo, out int opcaoTipo))
{
    Console.WriteLine("Opção inválida");
    return;
}
if(opcaoTipo != 1 && opcaoTipo != 2)
{
    Console.WriteLine("Escolha 1 ou 2.");
    return;
}

TipoMovimentacao tipo;
if (opcaoTipo == 1)
    tipo = TipoMovimentacao.Entrada;
else
    tipo = TipoMovimentacao.Saida;

Console.Write("Quantidade: ");
string? quantidadeProduto = Console.ReadLine();
if(!int.TryParse(quantidadeProduto, out int quantidade))
{
    Console.WriteLine("Quantidade inválida");
    return;
}


Console.Write("Descrição: ");
string? descricaoMovimentacao = Console.ReadLine();

if (string.IsNullOrWhiteSpace(descricaoMovimentacao))
{
    Console.WriteLine("A descrição do produto está nulo ou em branco.");
    return;
}


var movimentacao = new Movimentacao { CodigoProduto = codigoProduto, Quantidade = quantidade, Descricao = descricaoMovimentacao, Tipo = tipo };

var movimentadorEstoque = new MovimentadorEstoque();


try
{
    var quantidadeFinal = movimentadorEstoque.AplicarMovimentacao(produtos, movimentacao);
    Console.WriteLine($"Movimentação: {movimentacao.CodigoMovimentacao}, Registrada: {movimentacao.Tipo} de {movimentacao.Quantidade}");
    Console.WriteLine($" Descrição: {movimentacao.Descricao}, Estoque Final: {quantidadeFinal}");

}
catch(ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
Console.WriteLine("Desafio 3\n");

Console.WriteLine("Qual o valor da dívida:");
string? valorDivida = Console.ReadLine();

if(!decimal.TryParse(valorDivida, out decimal valor))
{
    Console.WriteLine("Esse valor não é número");
    return;
}

Console.WriteLine("Digite a data de vencimento (dd/mm/aaaa): ");
string? dataVencimento = Console.ReadLine();

if (!DateTime.TryParseExact(dataVencimento,"dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
{
    Console.WriteLine("Data inválida. Use o formato dd/mm/aaaa.");
    return;
}


var calcularJuros = new CalculadoraJuros();

try
{
    var juros = calcularJuros.CalcularJuros(valor, data);
    Console.WriteLine($"Juros: {juros}");
    Console.WriteLine($"Total a pagar: {juros + valor}");
}
catch(ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}