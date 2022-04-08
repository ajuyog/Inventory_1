using Dapper;
using Inventory_1.Models;
using Microsoft.Data.SqlClient;

namespace Inventory_1.Servicios
{
    public interface IRepositorioPersona
    {

    }
    public class RepositorioPersona: IRepositorioPersona
    {
        private readonly string ConnectionStrings;

        public RepositorioPersona(IConfiguration configuration)
        {
            ConnectionStrings = configuration.GetConnectionString("Connection_2");

        }

        public async Task CrearPersona(Personas personas)
        {
            using var connection = new SqlConnection(ConnectionStrings);

            var perId = await connection.QuerySingle
        }
    }
}
