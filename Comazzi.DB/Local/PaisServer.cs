
using Comazzi.Model;
using Dapper;

namespace Comazzi.DB.Local
{
    public class PaisServer(ConnectionStringProvider connectionStringProvider)
    {
        public async Task<Result<Pais>> Save(Sessao sessao, Pais pais)
        {
            return Result.Sucesso(pais);
        }


        public async Task<PagingResult<Pais>> List(Sessao sessao, int offset, int limit)
        {
            PagingResult<Pais> result = new PagingResult<Pais>();

            var sql = "SELECT count(*) from paises; SELECT pais_id,nome,bacen FROM paises;";

            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(connectionStringProvider.connectionString);

            using (var multi = connection.QueryMultiple(sql))
            {
               result.total = multi.Read<int>().Single();
                result.data = multi.Read<Pais>();

            }
            return result;
        }

    }
}
