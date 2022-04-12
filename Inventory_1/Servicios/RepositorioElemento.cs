using Microsoft.Data.SqlClient;

namespace Inventory_1.Servicios
{
    public interface IRepositorioElemento
    {

    }

    public class RepositorioElemento: IRepositorioElemento
    {

        private readonly string connectionStrings;

        public RepositorioElemento(IConfiguration configuration)
        {
            connectionStrings = configuration.GetConnectionString("Connection_2");
        }

        public async Task CrearElemento()
        {
            using var connention = new SqlConnection(connectionStrings);



        }

    }
}
