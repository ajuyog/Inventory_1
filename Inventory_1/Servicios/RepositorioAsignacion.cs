using Dapper;
using Inventory_1.Models;
using Microsoft.Data.SqlClient;

namespace Inventory_1.Servicios
{
    public interface IRepositorioAsignacion
    {
        Task CrearAsignacion(Asignacion asignacion);
        Task<bool> ExisteAsignacion(int Assembly_idAssembly);
        Task<IEnumerable<Asignacion>> Obtener();
    }

    public class RepositorioAsignacion: IRepositorioAsignacion
    {
        private readonly string connectionString;

        public RepositorioAsignacion(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Connection_2");
        }

        public async Task CrearAsignacion(Asignacion asignacion)
        {
            using var connection = new SqlConnection(connectionString);

            var id = await connection.QuerySingleAsync(@"insert into Assigment (Assembly_idAssembly, Person_idPerson) 
                                                        values (@Assembly_idAssembly, @Person_idPerson);
                                                        select Person_idPerson from Assigment 
                                                        where Assembly_idAssembly = @Assembly_idAssembly and 
                                                        Person_idPerson = @Person_idPerson;
                                                        ", asignacion);
            asignacion.Person_idPerson = id;
          
        }


        public async Task<IEnumerable<Asignacion>> Obtener()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Asignacion>(@"select Assembly_idAssembly, Person_idPerson from Assigment");
        }

        public async Task<bool> ExisteAsignacion(int Assembly_idAssembly)
        {
            using var connection = new SqlConnection(connectionString);

            var existeasignacion = await connection.QueryFirstOrDefaultAsync<int>(@" select 1 from Assigment where Assembly_idAssembly = @Assembly_idAssembly
                                                                                    ", new { Assembly_idAssembly });
            return existeasignacion == 1;
        }

    }
}
