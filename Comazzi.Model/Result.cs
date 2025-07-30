
namespace Comazzi.Model
{
    public class Result
    {
        public Result(bool sucesso, Erro? erro = null)
        {
            this.sucesso = sucesso;
            this.erro = erro;
        }

        public bool sucesso { get; }

        public Erro? erro { get; }

        public static Result Sucesso() => new(true, Erro.Nenhum);

        public static Result Falha(Erro error) => new(false, error);

        public static Result<T> Sucesso<T>(T data) => new(true, Erro.Nenhum, data);

        public static Result<T> Falha<T>(Erro erro) => new(false, erro, default);
    }

    public class Result<T> : Result
    {
        public T? data { get; }

        public Result(bool sucesso, Erro? erro, T? data) : base(sucesso, erro)
        {
            this.data = data;
        }
    }
}
