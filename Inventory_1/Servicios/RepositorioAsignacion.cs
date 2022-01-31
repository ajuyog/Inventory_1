using Dapper;
using Inventory_1.Models;
using Microsoft.Data.SqlClient;

namespace Inventory_1.Servicios
{
    public interface IRepositorioAsignacion
    {
        Task CrearAsignacion(Asignaciones asignaciones);
    }

    public class RepositorioAsignacion: IRepositorioAsignacion
    {
        private readonly string ConnectionStrings;
        public RepositorioAsignacion(IConfiguration configuration)
        {
            ConnectionStrings = configuration.GetConnectionString("Connection_2");
        }

        public async Task CrearAsignacion(Asignaciones asignaciones)
        {
            using var connection = new SqlConnection(ConnectionStrings);

            var Person_idPerson = await connection.QuerySingleAsync<string>($@"INSERT INTO Assigment (Assembly_idAssembly, Person_idPerson) 
                                                           VALUES (@Assembly_idAssembly, @Person_idPerson);
                                                           SELECT SCOPE_IDENTITY()", asignaciones);

            asignaciones.Person_idPerson = Person_idPerson;
        }
    }
}
