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
        Task<Asignaciones> ObtenerEnsamble(int Assembly_idAssembly);
    }

    //Conección a BD

    public class RepositorioAsignacion: IRepositorioAsignacion
    {
        private readonly string ConnectionStrings;
        public RepositorioAsignacion(IConfiguration configuration)
        {
            ConnectionStrings = configuration.GetConnectionString("Connection_2");
        }

        //Crear una asignación formulario

        public async Task CrearAsignacion(Asignaciones asignaciones)
        {
            using var connection = new SqlConnection(ConnectionStrings);

            var Person_idPerson = await connection.QuerySingleAsync<string>($@"INSERT INTO Assigment (Assembly_idAssembly, Person_idPerson) 
                                                                            VALUES (@Assembly_idAssembly, @Person_idPerson);
                                                                            SELECT Person_idPerson FROM Assigment 
                                                                            WHERE Person_idPerson = @Person_idPerson AND Assembly_idAssembly = @Assembly_idAssembly", asignaciones);

            asignaciones.Person_idPerson = Person_idPerson;
        }

        //Verificación de datos existente

        public async Task<bool> ExisteAsig(int Assembly_idAssembly, string Person_idPerson)
        {
            using var connection = new SqlConnection(ConnectionStrings);

            var existeAsig = await connection.QueryFirstOrDefaultAsync<int>($@"SELECT 1 FROM Assigment WHERE 
                                                                               Assembly_idAssembly = @Assembly_idAssembly AND Person_idPerson = @Person_idPerson;"
                                                                               , new {Assembly_idAssembly, Person_idPerson});
            return existeAsig == 1;

        }

        //Lista de asignaciones lista/Tabla

       public async Task<IEnumerable<Asignaciones>> Obtener()
        {
            using var connection = new SqlConnection(ConnectionStrings);

            return await connection.QueryAsync<Asignaciones>($@"SELECT Assembly_idAssembly, Person_idPerson FROM Assigment;");


        }


        //Editor asignación formulario

        public async Task Actualizar(Asignaciones asignaciones)
        {
            using var connection = new SqlConnection(ConnectionStrings);

            await connection.ExecuteAsync($@"UPDATE Assigment
                                        SET Person_idPerson = @Person_idPerson
                                        WHERE Assembly_idAssembly = @Assembly_idAssembly", asignaciones);
        }

        //verificación de ensamble

        public async Task<Asignaciones> ObtenerEnsamble(int Assembly_idAssembly)
        {
            using var connetion = new SqlConnection(ConnectionStrings);
            return await connetion.QueryFirstOrDefaultAsync<Asignaciones>($@"SELECT Assembly_idAssembly, Person_idPerson FROM Assigment 
                                                                          WHERE Assembly_idAssembly = @Assembly_idAssembly 
                                                                          ", new { Assembly_idAssembly });
        }


        //Eliminar registro de asignacion

        public async Task Borrar(int Person_idPerson,int Assembly_idAssembly)
        {
            using var connection = new SqlConnection(ConnectionStrings);

            await connection.ExecuteAsync($@"DELLETE Assigment
                                          WHERE Person_idPerson = @Person_idPerson AND Assembly_idAssembly = @Assembly_idAssembly", new { Person_idPerson, Assembly_idAssembly });
        }
      
    }
}
