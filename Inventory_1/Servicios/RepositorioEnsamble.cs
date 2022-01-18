using Dapper;
using Inventory_1.Models;
using Microsoft.Data.SqlClient;

namespace Inventory_1.Servicios
{
    public interface IRepositorioEnsamble
    {
        void CrearEnsamble(Ensamblajes ensamblajes);
    }
    public class RepositorioEnsamble: IRepositorioEnsamble
    {
        private readonly string connectionStrings;

        public RepositorioEnsamble(IConfiguration configuration)
        {
            connectionStrings = configuration.GetConnectionString("Connection_2");
        }

        public void CrearEnsamble(Ensamblajes ensamblajes)
        {
            using var connection = new SqlConnection(connectionStrings);

            var idAssambly = connection.QuerySingle<int>($@"INSERT INTO Assembly (Element_idElement, Assembly_idAssembly, serialnumber, codSecondary) 
                                                         VALUES (@Element_idElement, @Assembly_idAssembly, @serialnumber, @codSecondary); 
                                                         SELECT SCOPE_IDENTITY();", ensamblajes);
            ensamblajes.idAssambly = idAssambly;
        }
    }
}
