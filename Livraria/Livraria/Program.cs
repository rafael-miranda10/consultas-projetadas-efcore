using BenchmarkDotNet.Running;
using Livraria.Inserts;
using Livraria.Queries;


namespace Livraria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var dataSeed = new DataSeed();
            // dataSeed.Inserir_N_Autores(3000);

            var summary = BenchmarkRunner.Run<MyQueries>();
            var query = new MyQueries();
            //query.ConsultaDeAutoresEFCore();
            query.PrimeiraConexao();
            //query.ConsultarAutoresEFCore();
            //query.ConsultarAutoresLINQ();
            //query.ConsultaeAutoresEFCoreProjetada();
            query.ConsultaeAutoresEFCoreProjetada2();
            //query.ConsultaeAutoresEFCoreProjetadaAsNoTracking();
            //query.ConsultaeAutoresEFCoreProjetadaComResolucaoIdentidade();
            //query.ConsultarAutoresLINQProjetada();
            //query.ConsultarAutoresAutoMapperProjetada();
            //query.ConsultarAutoresAutoMapperProjetadaEspecifica();
        }
    }
}











