using Dapper;
using Inventory_1.Models;
using Microsoft.Data.SqlClient;

namespace Inventory_1.Servicios
{
    public interface IRepositorioEnsamble
    {
        Task Actualizar(Ensamblajes ensamblajes);
        Task CrearEnsamble(Ensamblajes ensamblajes);
        Task<IEnumerable<Ensamblajes>> Obtener();
        Task<Ensamblajes> ObtenerEnsamble(int Assembly_idAssembly);
        Task<IEnumerable<Ensamblajes>> ObtenerId();

        // Task<bool> Existe(int idAssambly);
    }
    public class RepositorioEnsamble: IRepositorioEnsamble
    {
        private readonly string connectionStrings;

        public RepositorioEnsamble(IConfiguration configuration)
        {
            connectionStrings = configuration.GetConnectionString("Connection_2");
        }

        public async Task CrearEnsamble(Ensamblajes ensamblajes)
        {
            using var connection = new SqlConnection(connectionStrings);

            var idAssambly = await connection.QuerySingleAsync<int>($@"INSERT INTO Assembly (Element_idElement, Assembly_idAssembly, serialnumber, codSecondary) 
                                                         VALUES (@Element_idElement, @Assembly_idAssembly, @serialnumber, @codSecondary); 
                                                         SELECT SCOPE_IDENTITY();", ensamblajes);
            ensamblajes.idAssambly = idAssambly;
        }


        public async Task<IEnumerable<Ensamblajes>> Obtener()
        {

            using var connection = new SqlConnection(connectionStrings);

            return await connection.QueryAsync<Ensamblajes>($@"SELECT idAssembly,Element_idElement,Assembly_idAssembly,serialnumber,codSecondary FROM Assembly");
        }


        //editar ensamblaje

        public async Task Actualizar(Ensamblajes ensamblajes)
        {
            using var connection = new SqlConnection(connectionStrings);

            await connection.ExecuteAsync($@"UPDATE Assembly SET 
                                            Element_idElement = @Element_idElement,  
                                            serialnumber= @serialnumber, 
                                            codSecondary= @codSecondary
                                            WHERE Assembly_idAssembly= @Assembly_idAssembly", ensamblajes);

        }

        //verificación de ensamble

        public async Task<Ensamblajes> ObtenerEnsamble(int Assembly_idAssembly)
        {
            using var connection = new SqlConnection(connectionStrings);
            return await connection.QueryFirstOrDefaultAsync<Ensamblajes>($@"SELECT idAssembly, Element_idElement, Assembly_idAssembly, serialnumber, codSecondary 
                                                                          FROM Assembly 
                                                                          WHERE Assembly_idAssembly = @Assembly_idAssembly 
                                                                          ", new { Assembly_idAssembly });
        }

        //lista ids

        public async Task<IEnumerable<Ensamblajes>> ObtenerId()
        {
            using var connection = new SqlConnection(connectionStrings);

            return await connection.QueryAsync<Ensamblajes>(@"SELECT idAssembly FROM Assembly");
        }


    }
    
}
