using Dapper;
using Inventory_1.Models;
using Microsoft.Data.SqlClient;

namespace Inventory_1.Servicios
{
    public interface IRepositorioAsignacion
    {
        void CrearAsignacion(Asignaciones asignaciones);
    }

    public class RepositorioAsignacion: IRepositorioAsignacion
    {
        private readonly string ConnectionStrings;
        public RepositorioAsignacion(IConfiguration configuration)
        {
            ConnectionStrings = configuration.GetConnectionString("Connection_2");
        }

        public void CrearAsignacion(Asignaciones asignaciones)
        {
            using var connection = new SqlConnection(ConnectionStrings);

            var Person_idPerson = connection.Query<string>($@"INSERT INTO Assigment (Assembly_idAssembly, Person_idPerson) 
                                                           VALUES (@Assembly_idAssembly, @Person_idPerson);
                                                           SELECT SCOPE_IDENTITY()", asignaciones);
        }
    }
}
