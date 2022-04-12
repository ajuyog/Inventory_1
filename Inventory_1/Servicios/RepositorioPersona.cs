using Dapper;
using Inventory_1.Models;
using Microsoft.Data.SqlClient;

namespace Inventory_1.Servicios
{
    public interface IRepositorioPersona
    {
        Task Actualizar(Personas personas);
        Task CrearPersona(Personas personas);
        Task<bool> ExistePerson(string idPerson);
        Task<IEnumerable<Personas>> Obtener();
        Task<Personas> ObtenerPersonas(string idPerson);
    }
    public class RepositorioPersona: IRepositorioPersona
    {
        private readonly string connectionStrings;

        public RepositorioPersona(IConfiguration configuration)
        {
            connectionStrings = configuration.GetConnectionString("Connection_2");
        }

        //Crear usuarios

        public async Task CrearPersona(Personas personas)
        {
            using var connection = new SqlConnection(connectionStrings);

            var idPerson = await connection.QuerySingleAsync<string>($@"INSERT INTO Person (idPerson, Area_idArea, PersonType_idPersonType, description, 
                                                      firstname, lastname, codeSecondary, active) VALUES (@idPerson, @Area_idArea, @PersonType_idPersonType, 
                                                      @description, @firstname, @lastname, @codeSecondary, @active);
                                                       SELECT idPerson FROM Person WHERE idPerson = @idPerson;", personas);

            personas.idPerson = idPerson;
        }


        //verificacion de dato

        public async Task<bool> ExistePerson(string idPerson)
        {
            using var connection = new SqlConnection(connectionStrings);

            var existePersona = await connection.QueryFirstOrDefaultAsync<int>($@"SELECT 1 FROM Person WHERE idPerson = @idPerson", new { idPerson });

            return existePersona == 1;
        }



        //Iteeracion de lista

        public async Task<IEnumerable<Personas>> Obtener()
        {
            using var connection = new SqlConnection(connectionStrings);

            return await connection.QueryAsync<Personas>($@"SELECT idPerson, Area_idArea, PersonType_idPersonType, description, firstname, lastname, codeSecondary, active FROM Person");
        }


        //editor

        public async Task Actualizar(Personas personas)
        {
            using var connection = new SqlConnection(connectionStrings);

            await connection.ExecuteAsync($@"UPDATE Person SET
                                            idPerson = @idPerson, 
                                            Area_idArea = @Area_idArea, 
                                            PersonType_idPersonType = @PersonType_idPersonType, 
                                            description = @description, 
                                            firstname = @firstname, 
                                            lastname = @lastname, 
                                            codeSecondary = @codeSecondary, 
                                            active = @active
                                            WHERE idPerson = @idPerson", personas);
        }

        //verificacion de datos para editor 

        public async Task<Personas> ObtenerPersonas(string idPerson)
        {
            using var connection = new SqlConnection(connectionStrings);

            return await connection.QueryFirstOrDefaultAsync<Personas>($@"SELECT idPerson, Area_idArea, PersonType_idPersonType, description, 
                                                                        firstname, lastname, codeSecondary, active 
                                                                        FROM Person WHERE idPerson = @idPerson", new { idPerson });
        }
    }
}
