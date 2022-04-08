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
        private readonly string connectionStrings;

        public RepositorioPersona(IConfiguration configuration)
        {

            connectionStrings = configuration.GetConnectionString("Connection_2");

        }

        public async Task CrearPersona(Personas personas)
        {
            using var connection = new SqlConnection(connectionStrings);

            var idPerson = await connection.QuerySingleAsync<string>($@"INSERT INTO Person (Area_idArea, PersonType_idPersonType, description, 
                                                                    firstname, lastname, 
                                                                    codeSecondary, active) values
                                                                    (@Area_idArea, @PersonType_idPersonType, @description, 
                                                                     @firstname, @lastname, @codeSecondary, @active)", personas);

            personas.idPerson = idPerson;
        }


    }
}
