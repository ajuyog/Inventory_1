using Dapper;
using Inventory_1.Models;
using Microsoft.Data.SqlClient;

namespace Inventory_1.Servicios
{
    public interface IRepositorioEnsamble
    {
        Task CrearEnsamble(Ensamblajes ensamblajes);
        Task<IEnumerable<Ensamblajes>> Obtener();
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

        /* public async Task<bool> Existe(int idAssambly)
         {
             using var connection = new SqlConnection(connectionStrings);
             var existe = await connection.QueryFirstOrDefaultAsync<int>(
                                           @"SELECT 1 FROM Assembly WHERE idAssembly = @idAssembly;",
                                           new { idAssambly });

                 return existe == 1;
         }*/

        public async Task<IEnumerable<Ensamblajes>> Obtener()
        {

            using var connection = new SqlConnection(connectionStrings);

            return await connection.QueryAsync<Ensamblajes>($@"SELECT idAssembly,Element_idElement,Assembly_idAssembly,serialnumber,codSecondary FROM Assembly");
        }
    }
    
}
