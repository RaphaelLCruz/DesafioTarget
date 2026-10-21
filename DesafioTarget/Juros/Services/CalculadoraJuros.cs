namespace DesafioTarget.Juros.Services
{
    public class CalculadoraJuros
    {
        public decimal CalcularJuros(decimal valorDivida, DateTime dataVencimento)
        {
            // Today em vez de Now: só a data importa, não a hora
            //Cannot implicitly convert type ‘System.TimeSpan’ to ‘int’
            // time span = um tipo que representa uma duração — um pedaço de tempo, sem dizer quando começou.
            TimeSpan atraso = DateTime.Today - dataVencimento;
            int diasAtraso = atraso.Days;
            
            if(diasAtraso <= 0)
            {
                return 0m;
            }
            if (valorDivida <= 0)
            {
                throw new ArgumentException($"“A quantidade deve ser maior que zero. Recebido:{valorDivida}");
            }

            decimal calculoJuros = (diasAtraso * 0.025m) * valorDivida;

            return Math.Round(calculoJuros, 2, MidpointRounding.AwayFromZero);

          
            
        }
    }
}
