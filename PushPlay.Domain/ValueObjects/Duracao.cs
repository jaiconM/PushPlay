namespace PushPlay.Domain.ValueObjects
{
    public class Duracao
    {
        private int _totalDeSegundos;

        public Duracao(int totalDeSegundos)
        {
            _totalDeSegundos = totalDeSegundos;
        }

        public override string ToString() => TimeSpan.FromSeconds(_totalDeSegundos).ToString("HH:mm:ss");
    }
}
