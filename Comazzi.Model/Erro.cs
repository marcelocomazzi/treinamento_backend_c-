namespace Comazzi.Model
{
    public class Erro
    {
        public Erro(string mensagem)
        {
            this.mensagem = mensagem;
        }

        public string mensagem { get; }

        public static Erro? Nenhum => null;

        public static implicit operator Erro(string mensagem) => new(mensagem);

        public static implicit operator string(Erro erro) => erro.mensagem;
    }
}
