namespace PushPlay.Domain.ValueObjects
{
    public class Duracao
    {
        public int Valor { get; set; }
        public string ValorFormatado => TimeSpan.FromSeconds(Valor).ToString("HH:mm:ss");

        protected Duracao() { /* for EF */ }

        public Duracao(int duracaoEmSegundos)
        {
            Valor = duracaoEmSegundos;
        }
    }
}
