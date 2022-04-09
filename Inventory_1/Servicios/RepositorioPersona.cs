using Dapper;
using Inventory_1.Models;
using Microsoft.Data.SqlClient;

namespace Inventory_1.Servicios
{
    public interface IRepositorioPersona
    {
        Task CrearPersona(Personas personas);
        Task<bool> Existe(string idPerson);
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

            var perId = await connection.QuerySingleAsync<string>($@"INSERT INTO Person 
                                                       (idPerson, Area_idArea, PersonType_idPersonType, description, 
                                                       firstname, lastname, codeSecondary, active) VALUES
                                                       (@idPerson, @Area_idArea, @PersonType_idPersonType, @description, 
                                                       @firstname, @lastname, @codeSecondary, @active);
                                                       SELECT idPerson FROM Person WHERE idPerson = @idPerson", personas);
            personas.idPerson = perId;
        }

        public async Task<bool> Existe(string idPerson)
        {
            using var connection = new SqlConnection(ConnectionStrings);

            var existPerson = await connection.QueryFirstOrDefaultAsync<int>($@"SELECT 1 FROM Person WHERE idPerson = @idPerson", new { idPerson });

            return existPerson == 1;

        }
    }
}
