using Dapper;
using Inventory_1.Models;
using Microsoft.Data.SqlClient;

namespace Inventory_1.Servicios
{
    public interface IRepositorioAsignacion
    {
        Task Actualizar(Asignaciones asignaciones);
        Task CrearAsignacion(Asignaciones asignaciones);
        Task<bool> ExisteAsig(int Assembly_idAssembly, string Person_idPerson);
        Task<IEnumerable<Asignaciones>> Obtener();
        //Task<Asignaciones> ObtenerAsig(int Assembly_idAssembly, string Person_idPerson);
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

        public async Task<bool> ExisteAsig(int Assembly_idAssembly, string Person_idPerson)
        {
            using var connection = new SqlConnection(ConnectionStrings);

            var existeAsig = await connection.QueryFirstOrDefaultAsync<int>($@"SELECT 1 FROM Assigment WHERE 
                                                                               Assembly_idAssembly = @Assembly_idAssembly AND Person_idPerson = @Person_idPerson;"
                                                                               , new {Assembly_idAssembly, Person_idPerson});
            return existeAsig == 1;

        }

       public async Task<IEnumerable<Asignaciones>> Obtener()
        {
            using var connection = new SqlConnection(ConnectionStrings);

            return await connection.QueryAsync<Asignaciones>($@"SELECT Assembly_idAssembly, Person_idPerson FROM Assigment;");


        }

        public async Task Actualizar(Asignaciones asignaciones)
        {
            using var connection = new SqlConnection(ConnectionStrings);

            await connection.ExecuteAsync($@"UPDATE Assigment
                                        SET Assembly_idAssembly = @Assembly_idAssembly, Person_idPerson = @Person_idPerson
                                        WHERE Person_idPerson = @Person_idPerson;", asignaciones);
        }

       /* public async Task<Asignaciones> ObtenerAsig(int Assembly_idAssembly, string Person_idPerson)
        {
            using var connection = new SqlConnection(ConnectionStrings);

            return await connection.QueryFirstOrDefaultAsync<Asignaciones>($@"SELECT Assembly_idAssembly, Person_idPerson
                                                                            FROM Assigment
                                                                            WHERE Assembly_idAssembly = @Assembly_idAssembly 
                                                                            AND Person_idPerson = @Person_idPerson;", new {Assembly_idAssembly, Person_idPerson});
        }*/
    }
}
